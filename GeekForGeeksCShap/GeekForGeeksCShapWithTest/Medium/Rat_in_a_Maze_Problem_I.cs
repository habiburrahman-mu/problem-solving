using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeksCShapWithTest.Medium
{
    public class Rat_in_a_Maze_Problem_I
    {
        public List<string> Solution(List<List<int>> mat)
        {
            return new List<string>();
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new List<List<int>>
                {
                    new List<int> { 1, 0 },
                    new List<int> { 1, 0 }
                },
                new List<string> { }  // Output is empty (no solution)
            };

            yield return new object[]
            {
                new List<List<int>>
                {
                    new List<int> { 1, 0, 0, 0 },
                    new List<int> { 1, 1, 0, 1 },
                    new List<int> { 1, 1, 0, 0 },
                    new List<int> { 0, 1, 1, 1 }
                },
                new List<string> { "DDRDRR", "DRDDRR" }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void _014_Longest_Common_Prefix_Test(List<List<int>> mat, List<string> output)
        {
            // Arrange
            var sut = Solution;

            // Act
            var result = sut(mat);

            // Assert
            Assert.Equal(output, result);
        }
    }
}
