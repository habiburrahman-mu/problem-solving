using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class _014_Longest_Common_Prefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var result = string.Empty;

            if (strs.Length < 2)
            {
                result = strs.Length > 0 ? strs[0] : result;
                return result;
            }


            string first = strs[0];
            for (int i = 0; i < first.Length; i++)
            {
                char currentCh = first[i];

                for (int j = 1; j < strs.Length; j++)
                {
                    string comparingWord = strs[j];
                    if (i == comparingWord.Length || currentCh != comparingWord[i])
                        return result;
                }

                result += currentCh;
            }

            return result;
        }

        [Theory]
        [InlineData((string[])["flower", "flow", "flight"], "fl")]
        [InlineData((string[])["dog", "racecar", "car"], "")]
        public void _014_Longest_Common_Prefix_Test(string[] strs, string expected)
        {
            // Arrange
            var sut = LongestCommonPrefix;

            // Act
            var result = sut(strs);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
