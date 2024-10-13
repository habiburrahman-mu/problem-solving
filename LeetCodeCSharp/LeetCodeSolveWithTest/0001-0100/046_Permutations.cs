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
            return [[1]];
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
        //[InlineData((int[])[1, 2, 3], new[] { new int[] { 1, 2, 3 } })]
        public void _046_Permutations_Test(int[] nums, int[][] expected)
        {
            // Arrange
            var sut = Permute;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
