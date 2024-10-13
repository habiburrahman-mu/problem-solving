using System.Diagnostics;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _001_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> complementIndex = new();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (complementIndex.ContainsKey(complement))
                {
                    return new[] { complementIndex[complement], i};
                }

                complementIndex[nums[i]] = i;
            }

            return new int[] { };
        }


        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        public void _001_TwoSum_Test(int[] nums, int target, int[] expected)
        {
            // Arrange
            var sut = TwoSum;

            // Act
            var result = sut(nums, target);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}