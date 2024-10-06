using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0201_0300
{
    public class _211_Design_Add_and_Search_Words_Data_Structure
    {
        private class TrieNode
        {
            public TrieNode?[] Child;
            public bool WordEnd;

            public TrieNode()
            {
                Child = new TrieNode?[26];
                WordEnd = false;
            }
        }

        private class WordDictionary
        {
            TrieNode root;
            public WordDictionary()
            {
                root = new TrieNode();
            }

            public void AddWord(string word)
            {
                var current = root;
                foreach (char ch in word)
                {
                    var index = ch - 'a';
                    if (current.Child[index] == null)
                        current.Child[index] = new TrieNode();
                    current = current.Child[index];
                }
                current.WordEnd = true;
            }

            public bool Search(string word)
            {
                return SearchWord(root, word, 0);
            }

            private bool SearchWord(TrieNode current, string word, int index)
            {
                if(index == word.Length)
                {
                    return current.WordEnd;
                }

                char ch = word[index];
                if(ch == '.')
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (current.Child[i] != null && SearchWord(current.Child[i]!, word, index + 1))
                            return true;
                    }

                    return false;
                }
                else
                {
                    var charIndex = ch - 'a';
                    if (current.Child[charIndex] == null)
                    {
                        return false; // No matching child node
                    }

                    return SearchWord(current.Child[charIndex]!, word, index + 1);
                }
            }
        }

        [Fact]
        public void _211_Design_Add_and_Search_Words_Data_Structure_Test()
        {
            var wordDictionary = new WordDictionary();

            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");

            Assert.False(wordDictionary.Search("pad")); // Should return False
            Assert.True(wordDictionary.Search("bad"));  // Should return True
            Assert.True(wordDictionary.Search(".ad"));  // Should return True
            Assert.True(wordDictionary.Search("b.."));  // Should return True
        }
    }
}
