using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._201_300
{
    public class _242_Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            var sMap = new Dictionary<char, int>();
            var tMap = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (sMap.ContainsKey(ch))
                {
                    sMap[ch] += 1;
                }
                else
                {
                    sMap.Add(ch, 1);
                }
            }

            foreach (var ch in t)
            {
                if (tMap.ContainsKey(ch))
                {
                    tMap[ch] += 1;
                }
                else
                {
                    tMap.Add(ch, 1);
                }
            }

            foreach (var ch in sMap.Keys)
            {
                if (!tMap.ContainsKey(ch))
                    return false;
                if (sMap[ch] != tMap[ch])
                    return false;
                sMap.Remove(ch);
                tMap.Remove(ch);
            }

            return tMap.Count == 0;
        }

        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        [InlineData("a", "ab", false)]

        public void _242_Valid_Anagram_Tests(string s, string t, bool expected)
        {
            // Arrange
            var sut = IsAnagram;

            // Act
            var result = sut(s, t);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
