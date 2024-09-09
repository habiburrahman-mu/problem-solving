namespace LeetCodeSolveWithTest._701_800
{

    public class _704_Binary_Search
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) / 2); // (left + right) / 2 can lead to overflow
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        [Theory]
        [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
        [InlineData(new[] { 5 }, 5, 0)]
        public void _704_Binary_Search_Test(int[] nums, int target, int expected)
        {
            // Arrange
            var sut = Search;

            // Act
            var result = sut(nums, target);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
