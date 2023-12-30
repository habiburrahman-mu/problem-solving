using System.Diagnostics;

namespace LeetCodeSolveWithTest
{
    public class _001_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            throw new NotImplementedException();
        }


        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        public void _001_TwoSum_Test(int[] nums, int target, int[] expected)
        {
            // Arrange
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Act
            var result = TwoSum(nums, target);

            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");

            // Assert
            Assert.Equal(expected, result);
        }
    }
}