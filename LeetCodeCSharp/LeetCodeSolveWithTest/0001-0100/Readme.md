# 001 - 100

## 14. [Longest Common Prefix](https://leetcode.com/problems/longest-common-prefix)

### Intuition

The problem requires finding the longest common prefix from an array of strings. A common strategy involves comparing characters at the same position across all strings, stopping when a mismatch occurs. Alternatively, a Trie (Prefix Tree) can be employed, where the common prefix can be found by traversing the tree as long as there is only one path downwards.

---

### Approach 1: Character-by-Character Comparison

#### Approach

1. If the array has only one string, return it as the prefix.
2. Use the first string as the reference and iterate through each of its characters.
3. For each character, compare it with the character at the same position in all other strings.
4. If a mismatch is found or the length of a string is less than the current index, return the accumulated result as the common prefix.
5. Continue adding matching characters to the result until a mismatch is encountered.

#### Complexity

- Time complexity:

    $O(n \times m)$, where:
    - $n$ is the number of strings.
    - $m$ is the length of the first string. The worst-case scenario compares every character of the first string with all others.
- Space complexity:

    $O(m)$ where $m$ is the length of the longest common prefix.

#### Code

```csharp
public class Solution {
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
}

```

---

### Approach 2: Using Trie (Prefix Tree)

#### Approach

1. Define a `TrieNode` class to represent nodes in a Trie, keeping track of its children, the number of children, and whether it marks the end of a word.
2. Insert each word from the array into the Trie.
    - For each character in a word, calculate its index (based on 'a') and insert it into the Trie if it’s not already present.
3. To find the longest common prefix:
    - Traverse from the root of the Trie, moving to the child node if there is exactly one child and it’s not the end of a word.
    - Append each traversed character to the result.
4. Stop when there are multiple children or the node represents the end of a word, as the common prefix can no longer extend.

#### Complexity

- Time complexity:

    $O(n \times m)$, where:

    - $n$ is the number of words.
    - $m$ is the average length of the words.
    
    The time complexity includes inserting words into the Trie and traversing to find the common prefix.
    
- Space complexity:
    
    $O(n \times m)$, as the Trie structure stores up to $n \times m$ characters, with each character represented as a node.
    

#### Code

```csharp
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

public class Solution {
    private readonly TrieNode root;

    public Solution()
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
}

```

---

## 46. [Permutations](https://leetcode.com/problems/permutations)

### Intuition

The problem requires generating all permutations of a list of integers. We can approach this by recursively building permutations, either by inserting elements in all positions of smaller permutations or by swapping elements in place.

### Approaches

#### Approach 1: Recursively Inserting Elements

In this approach, we recursively generate permutations of the remaining elements starting from the second element. Once we have all permutations for the remaining elements, we insert the current element at every possible position in each of those smaller permutations. This generates all permutations including the current element.

#### Code

```csharp
public class Solution {
    public IList<IList<int>> Permute(int[] nums)
    {
        return GetAllPermutations(nums, 0);
    }

    private IList<IList<int>> GetAllPermutations(int[] nums, int start)
    {
        if (start == nums.Length - 1)
        {
            return new List<IList<int>> { new List<int> { nums[start] } };
        }

        var permutationList = new List<IList<int>>();
        var currentElement = nums[start];
        var subPermutationList = GetAllPermutations(nums, start + 1);

        foreach (var permutation in subPermutationList)
        {
            for (int index = 0; index <= permutation.Count; index++)
            {
                var newPermutation = permutation.ToList();
                newPermutation.Insert(index, currentElement);
                permutationList.Add(newPermutation);
            }
        }
        return permutationList;
    }
}

```

#### Complexity Analysis

- **Time complexity:**
    
    The time complexity for this approach is $O(N! \cdot N^2)$. Here's the breakdown:
    
    - There are $N!$ permutations in total.
    - For each permutation, you need to insert the current element at every possible position in all permutations of the remaining $N-1$ elements.
    - For each insertion, we take a copy of the previous permutation (which takes $O(N)$) and insert the element into all positions (which can take up to $O(N)$ for each permutation).
    - Therefore, the overall time complexity is $O(N! \cdot N^2)$, accounting for both the $O(N!)$ recursive calls and the $O(N^2)$ work done in each call.
- **Space complexity:**
    
    The space complexity remains $O(N! \cdot N)$. This is because we store $N!$ permutations, each of size $N$, and the recursion stack has a depth of $O(N)$.

---

#### Approach 2: Backtracking with Swapping

In this approach, we swap elements in the array to create permutations in-place. By swapping the current element with every element that comes after it, we generate all permutations recursively. After processing each permutation, we swap the elements back to restore the original order (backtracking).

##### Code

```csharp
public class Solution {
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        GetAllPermutations2(nums, 0, result);
        return result;
    }

    private void GetAllPermutations2(int[] nums, int start, IList<IList<int>> result)
    {
        if (start == nums.Length)
        {
            var list = nums.ToArray();
            result.Add(list);
            return;
        }

        for (int i = start; i < nums.Length; i++)
        {
            (nums[i], nums[start]) = (nums[start], nums[i]);
            GetAllPermutations2(nums, start + 1, result);
            (nums[i], nums[start]) = (nums[start], nums[i]);  // backtrack
        }
    }
}

```

##### Complexity Analysis

- **Time complexity:**
    
    As mentioned earlier, the time complexity for this approach is $O(N!)$ because there are $N!$ permutations to generate, and each recursive call performs constant-time operations (swapping and backtracking).
    
- **Space complexity:**
    
    The space complexity is $O(N! \cdot N)$, dominated by the storage of $N!$ permutations, each of size $N$. The recursion stack depth is $O(N)$, which is negligible compared to the space for storing the permutations.

## 100. [Same Tree](https://leetcode.com/problems/same-tree)

### Intuition

The problem is asking whether two binary trees are identical. Two trees are considered identical if they have the same structure and their corresponding nodes have the same values. The first thought that comes to mind is to traverse both trees simultaneously and compare each node. If all corresponding nodes in both trees are identical, the trees are the same; otherwise, they are not.

## Approach

To solve this problem, we can use recursion to traverse both trees simultaneously. At each step, we'll check if the current nodes in both trees have the same value. If they do, we'll recursively check their left and right subtrees. The base case for our recursion will be when both nodes are `null`, indicating that we've reached the end of both subtrees.

**Steps:**

1. If both nodes are `null`, return `true`.
2. If one node is `null` and the other is not, return `false`.
3. If the values of the current nodes are not the same, return `false`.
4. Recursively check the left subtrees and right subtrees.
5. Return `true` if both left and right subtree checks return `true`.

## Complexity

- **Time complexity:**

    The time complexity is $O(n)$, where `n` is the total number of nodes in the smaller of the two trees. In the worst case, we visit each node once.

- **Space complexity:**

    The space complexity is $O(h)$, where `h` is the height of the tree. This space is used by the recursion stack. In the worst case (unbalanced tree), this could be $O(n)$, and in the best case (balanced tree), it would be $O(\log n)$.

## Code

```csharp
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // Both nodes are null, trees are the same
        if (p == null && q == null) return true;

        // One of the nodes is null, trees are not the same
        if (p == null || q == null) return false;

        // Values of the current nodes are different, trees are not the same
        if (p.val != q.val) return false;

        // Recursively check the left and right subtrees
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
```
