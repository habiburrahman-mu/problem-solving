using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _046_Permutations
    {
        private IList<IList<int>> Permute(int[] nums)
        {
            return GetAllPermutations(nums, 0);
        }

        private IList<IList<int>> GetAllPermutations(int[] nums, int start)
        {
            if (start == nums.Length - 1)
            {
                return [[nums[start]]];
            }

            var permutationList = new List<List<int>>();
            var currentElement = nums[start];
            var subPermutionList = GetAllPermutations(nums, start + 1);
            foreach (var permutation in subPermutionList)
            {
                for (int index = 0; index < permutation.Count + 1; index++)
                {
                    var newPermutation = permutation.ToList();
                    newPermutation.Insert(index, currentElement);
                    permutationList.Add(newPermutation);
                }
            }
            return permutationList.ToArray();
        }

        public static IEnumerable<object[]> PermutationTestData()
        {
            yield return new object[]
            {
                new int[] { 1, 2, 3 },
                new int[][]
                {
                    [ 1, 2, 3 ],
                    [ 1, 3, 2 ],
                    [ 2, 1, 3 ],
                    [ 2, 3, 1 ],
                    [ 3, 1, 2 ],
                    [ 3, 2, 1 ]
                }
            };

            yield return new Object[]
            {
                new int[] { 0, 1 },
                new int[][]
                {
                    [0,1],
                    [1, 0 ]
                }
            };

            yield return new object[]
            {
                new int[] { 1 },
                new int[][]
                {
                    [1]
                }
            };
        }

        [Theory]
        [MemberData(nameof(PermutationTestData))]
        public void _046_Permutations_Test(int[] nums, int[][] expected)
        {
            // Arrange
            var sut = Permute;

            // Act
            var result = sut(nums);

            var expectedSet = new HashSet<string>(expected.Select(x => string.Join(",", x)));
            var resultSet = new HashSet<string>(result.Select(x => string.Join(",", x)));

            // Assert
            Assert.Equal(expectedSet, resultSet);
        }
    }
}
