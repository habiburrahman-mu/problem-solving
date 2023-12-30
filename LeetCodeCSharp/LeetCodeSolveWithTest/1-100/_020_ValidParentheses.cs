namespace LeetCodeSolveWithTest
{
    public class _020_ValidParentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in s)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                    continue;
                }

                if (stack.Count == 0)
                    return false;


                var popped = stack.Pop();

                switch (ch)
                {
                    case ')':
                        if (popped != '(')
                            return false;
                        break;
                    case '}':
                        if (popped != '{')
                            return false;
                        break;
                    case ']':
                        if (popped != '[')
                            return false;
                        break;
                }
            }

            return stack.Count == 0;
        }


        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        public void _020_ValidParentheses_Test(string s, bool expected)
        {
            // Arrange
            var sut = IsValid;

            // Act
            var result = sut(s);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}