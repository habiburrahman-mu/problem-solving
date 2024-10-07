using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0001_0100
{
    public class TrieNode
    {
        public TrieNode?[] Child;
        public int ChildCount;
        public bool WordEnd;

        public TrieNode()
        {
            Child = new TrieNode?[26];
            ChildCount = 0;
            WordEnd = false;
        }
    }

    public class _014_Longest_Common_Prefix
    {
        private readonly TrieNode root;
        public _014_Longest_Common_Prefix()
        {
            root = new TrieNode();
        }

        private void InsertWord(string word)
        {
            var current = root;

            foreach (char ch in word)
            {
                int index = ch - 'a';
                if (current!.Child[index] == null)
                {
                    current.Child[index] = new TrieNode();
                    current.ChildCount++;
                }
                current = current.Child[index];
            }

            current.WordEnd = true;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string str in strs)
                InsertWord(str);

            var first = strs[0];
            var current = root;
            foreach (char ch in first)
            {
                int index = ch - 'a';
                if (current!.ChildCount > 1 || current.WordEnd) 
                    break;
                stringBuilder.Append(ch);
                current = current!.Child[index];
            }

            return stringBuilder.ToString();
        }

        [Theory]
        [InlineData((string[])["flower", "flow", "flight"], "fl")]
        [InlineData((string[])["dog", "racecar", "car"], "")]
        [InlineData((string[])["ab", "a"], "a")]
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
