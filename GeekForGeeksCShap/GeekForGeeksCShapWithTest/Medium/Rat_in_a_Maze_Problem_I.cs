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
            var ans = new List<string>();
            var n = mat.Count;

            // Edge case: if the matrix is empty or the starting point is blocked, return empty result.
            if (n == 0 || mat[0][0] == 0)
                return ans;

            var visited = Enumerable.Range(0, mat.Count)
                        .Select(_ => Enumerable.Repeat(0, mat[0].Count).ToList())
                        .ToList(); ;
            string path = string.Empty;

            Solve(0, 0, mat, n, ans, visited, path);

            return ans;
        }

        void Solve(int x, int y, List<List<int>> mat, int n, List<string> ans, List<List<int>> visited, string path)
        {
            if (x == n - 1 && y == n - 1)
            {
                ans.Add(path);
                return;
            }

            visited[x][y] = 1;

            // Down
            if (IsSafe(x + 1, y, visited, mat, n))
            {
                Solve(x + 1, y, mat, n, ans, visited, path + "D");
            }

            // Left
            if (IsSafe(x, y - 1, visited, mat, n))
            {
                Solve(x, y - 1, mat, n, ans, visited, path + "L");
            }

            // Right
            if (IsSafe(x, y + 1, visited, mat, n))
            {
                Solve(x, y + 1, mat, n, ans, visited, path + "R");
            }

            // Up
            if (IsSafe(x - 1, y, visited, mat, n))
            {
                Solve(x - 1, y, mat, n, ans, visited, path + "U");
            }

            visited[x][y] = 0;

        }

        bool IsSafe(int newx, int newy, List<List<int>> visited, List<List<int>> mat, int n)
        {
            bool isSafe = newx >= 0 && newy >= 0
                && newx < n && newy < n
                && visited[newx][newy] != 1
                && mat[newx][newy] != 0;

            return isSafe;
        }

        public static IEnumerable<object[]> GetTestData()
        {
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

            yield return new object[]
            {
                new List<List<int>>
                {
                    new List<int> { 1, 0 },
                    new List<int> { 1, 0 }
                },
                new List<string> { }  // Output is empty (no solution)
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
