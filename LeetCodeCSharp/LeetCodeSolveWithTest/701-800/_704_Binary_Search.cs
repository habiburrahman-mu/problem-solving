namespace LeetCodeSolveWithTest._701_800
{

    public class _704_Binary_Search
    {
        public int Search(int[] nums, int target)
        {
            return 0;
        }

        [Theory]
        [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
        [InlineData(new[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
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
