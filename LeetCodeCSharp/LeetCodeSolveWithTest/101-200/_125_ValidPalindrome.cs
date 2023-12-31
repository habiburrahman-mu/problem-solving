namespace LeetCodeSolveWithTest._101_200
{
    public class _125_ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(" ", true)]

        public void _125_ValidPalindrome_Test(string prices, bool expected)
        {
            // Arrange
            var sut = MaxProfit;

            // Act
            var result = sut(prices);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
