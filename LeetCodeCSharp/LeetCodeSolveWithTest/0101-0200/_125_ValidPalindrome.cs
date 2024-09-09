namespace LeetCodeSolveWithTest._101_200
{
    public class _125_ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                if (!char.IsAsciiLetterOrDigit(s[left]))
                    left++;
                else if (!char.IsAsciiLetterOrDigit(s[right]))
                    right--;
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                        return false;
                    left++;
                    right--;
                }
            }
            return true;
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
