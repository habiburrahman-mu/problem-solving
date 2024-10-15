using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _078_Subsets
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var solutionList = new List<IList<int>> { (int[])[] };

            foreach (int number in nums)
            {
                List<IList<int>> localSolutionList = new();
                foreach (var solution in solutionList)
                {
                    var newSolution = solution.ToList();
                    newSolution.Add(number);
                    localSolutionList.Add(newSolution);
                }
                solutionList.AddRange(localSolutionList);
            }
            return solutionList;
        }

        public static IEnumerable<object[]> SubsetsTestData()
        {
            yield return new object[]
            {
                new int[] { 1, 2, 3 },
                new int[][]
                {
                    [],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]
                }
            };

            yield return new Object[]
            {
                new int[] { 0 },
                new int[][]
                {
                    [],[0]
                }
            };
        }

        [Theory]
        [MemberData(nameof(SubsetsTestData))]
        public void _O78_Subsets_Test(int[] nums, int[][] expected)
        {
            var sut = Subsets;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
