# 201 - 300

## 208. [Implement Trie (Prefix Tree)](https://leetcode.com/problems/implement-trie-prefix-tree)

### 208. Intuition

The Trie (Prefix Tree) data structure is well-suited for efficiently storing and searching words, particularly when we need to check if words or prefixes exist. Given that each node can have 26 children (for each letter of the alphabet), we can traverse the Trie as we insert or search for words. Each node represents a character, and the traversal is based on the characters in the word.

### 208. Approach

1. **TrieNode Structure**: Each `TrieNode` holds an array `Child` of size 26 to represent the possible children nodes (one for each lowercase letter) and a boolean `WordEnd` to mark if a word ends at that node.
2. **Insert**: To insert a word, we traverse the Trie starting from the root. For each character in the word, we compute its index (using the difference between the character and 'a'), and if the corresponding child is null, we create a new node. At the end of the word, we mark the `WordEnd` flag as true.
3. **Search**: To search for a word, we follow the same traversal as the insert operation. If at any point a character’s corresponding child is null, the word doesn't exist. If we reach the end of the word and the `WordEnd` flag is true, the word exists in the Trie.
4. **StartsWith**: Similar to the search, but we only check if the prefix exists by traversing the Trie. There's no need to check for the `WordEnd` flag.

```csharp
public class TrieNode
{
    public TrieNode?[] Child;
    public bool WordEnd;
    public TrieNode()
    {
        Child = new TrieNode?[26];
        WordEnd = false;
    }
}

public class Trie {

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

```

### 208. Complexity Analysis

- Time complexity:
  - **Insert**: For each word, we process each character once. Thus, the time complexity is $O(m)$, where $m$ is the length of the word.
  - **Search**: Similar to insert, the time complexity is $O(m)$ for a word of length $m$.
  - **StartsWith**: This also requires processing each character of the prefix, so the time complexity is $O(m)$ for a prefix of length $m$.

- Space complexity:
  - **Insert**: In the worst case, each node in the Trie can have up to 26 children. The space complexity depends on the total number of characters inserted, so it is $O(n \times m)$, where $n$ is the number of words, and $m$ is the average length of the words.
  - **Search** and **StartsWith** don't use additional space aside from the Trie, so their space complexity is $O(1)$.

## 211. [Design Add and Search Words Data Structure](https://leetcode.com/problems/design-add-and-search-words-data-structure)

### 211. Intuition

The problem requires designing a data structure that supports adding words and searching for words with wildcards. A Trie (prefix tree) is an ideal choice for this because:

1. It efficiently stores strings with common prefixes
2. It allows for quick prefix-based searches
3. Its tree structure naturally supports recursive searching for wildcard characters

### 211. Approach

1. **Data Structure**:
    - Use a Trie where each node contains:
        - An array of 26 child nodes (for lowercase English letters)
        - A boolean flag indicating if it's the end of a word
2. **Adding Words**:
    - Iterate through each character in the word
    - For each character, create a new node if it doesn't exist
    - Mark the last node as a word endpoint
3. **Searching Words**:
    - Use recursive depth-first search
    - For regular characters, follow the corresponding path
    - For '.' (dot), try all possible paths
    - Return true if we reach the end of the word at a valid word endpoint

### 211. Code

```csharp
public class TrieNode
{
    public TrieNode?[] Child;
    public bool WordEnd;

    public TrieNode()
    {
        Child = new TrieNode?[26];
        WordEnd = false;
    }
}

public class WordDictionary
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
```

### 211. Complexity Analysis

- Time complexity:
  - AddWord: $O(m)$, where m is the length of the word
  - Search:
    - Best case (no dots): $O(m)$
    - Worst case (with dots): $O(26² * m)$, where $m$ is the length of the word
      - Since there are at most 2 dots, we need to try all 26 possibilities for each dot.

- Space complexity:
  - $O(N)$, where $N$ is the total number of characters in all added words
  - In the worst case, this could be $O(26^m)$ where $m$ is the maximum word length.
  