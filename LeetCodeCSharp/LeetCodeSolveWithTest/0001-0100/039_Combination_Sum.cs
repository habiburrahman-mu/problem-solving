using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _039_Combination_Sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new();
            List<int> currentCombination = new();
            BackTrack(candidates, 0, target, 0, currentCombination, result);
            return result;
        }

        private static void BackTrack(int[] candidates, int start, int target, int currentSum, List<int> currentCombination, List<IList<int>> result)
        {
            if (currentSum == target)
            {
                result.Add(new List<int>(currentCombination));
                return;
            }

            if (currentSum > target) return;

            for (int i = start; i < candidates.Length; i++)
            {
                currentCombination.Add(candidates[i]);
                BackTrack(candidates, i, target, currentSum + candidates[i], currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        public static IEnumerable<object[]> CombinationSumTestData()
        {
            yield return new object[]
            {
                new int[] { 2,3,6,7 },
                7,
                new int[][]
                {
                    [2,2,3],[7]
                }
            };

            yield return new Object[]
            {
                new int[] { 2,3,5 },
                8,
                new int[][]
                {
                    [2,2,2,2],[2,3,3],[3,5]
                }
            };
        }

        [Theory]
        [MemberData(nameof(CombinationSumTestData))]
        public void _O78_Subsets_Test(int[] nums, int target, int[][] expected)
        {
            var sut = CombinationSum;

            // Act
            var result = sut(nums, target);

            expected = expected
                .OrderBy(list => list.Count())
                .ThenBy(list => string.Join(",", list))
                .ToArray();

            result = result
                .OrderBy(list => list.Count())
                .ThenBy(list => string.Join(",", list))
                .ToList();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
