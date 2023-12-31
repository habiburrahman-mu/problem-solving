namespace LeetCodeSolveWithTest._101_200
{
    public class _125_ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            var clean = s.ToLower().Where(char.IsLetterOrDigit);
            return clean.Reverse().SequenceEqual(clean);
        }

        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(" ", true)]

        public void _125_ValidPalindrome_Test(string s, bool expected)
        {
            // Arrange
            var sut = IsPalindrome;

            // Act
            var result = sut(s);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
