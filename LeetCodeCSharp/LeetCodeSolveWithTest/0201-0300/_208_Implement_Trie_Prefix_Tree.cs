using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0201_0300
{
    public class _208_Implement_Trie_Prefix_Tree
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

        private class Trie
        {
            private TrieNode root;
            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                var current = root;

                foreach (char ch in word)
                {
                    var index = ch - 'a';
                    if (current.Child[index] == null)
                    {
                        current.Child[index] = new TrieNode();
                    }

                    current = current.Child[index];
                }

                current.WordEnd = true;
            }

            public bool Search(string word)
            {
                var current = root;

                foreach (char ch in word)
                {
                    var index = ch - 'a';

                    if (current.Child[index] == null)
                        return false;

                    current = current.Child[index];
                }

                return current.WordEnd;
            }

            public bool StartsWith(string prefix)
            {
                var current = root;

                foreach (char ch in prefix)
                {
                    var index = ch - 'a';

                    if (current.Child[index] == null)
                        return false;

                    current = current.Child[index];
                }

                return true;
            }
        }

        [Fact]
        public void TestTrieOperations()
        {
            var trie = new Trie();
            trie.Insert("apple");
            Assert.True(trie.Search("apple"));
            Assert.False(trie.Search("app"));
            Assert.True(trie.StartsWith("app"));
            trie.Insert("app");
            Assert.True(trie.Search("app"));
        }
    }
}
