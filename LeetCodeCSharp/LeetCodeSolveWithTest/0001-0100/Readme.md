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

## 17. [Letter Combinations of a Phone Number](https://leetcode.com/problems/letter-combinations-of-a-phone-number)

### Intuition

The problem requires generating all possible letter combinations that can correspond to a given phone number, where each digit maps to a set of letters. The task can be approached using backtracking to explore all combinations systematically.

### Approach

- **Mapping Digits to Letters**: We define a dictionary that maps each digit (from 2 to 9) to its corresponding letters.
- **Backtracking**: A recursive method (`BackTrack`) is used to build combinations:
    - If the length of the current combination equals the length of the input digits, we add it to the result list.
    - For each digit, we iterate over its mapped characters, appending one character to the current combination and recursively calling the method for the next digit.
    - After exploring a character, we remove it to backtrack and try the next character.

### Code

```csharp
public class Solution {
    private Dictionary<char, List<string>> _map = new()
    {
        {'2', new() {"a", "b", "c"}},
        {'3', new() {"d", "e", "f"}},
        {'4', new() {"g", "h", "i"}},
        {'5', new() {"j", "k", "l"}},
        {'6', new() {"m", "n", "o"}},
        {'7', new() {"p", "q", "r", "s"}},
        {'8', new() {"t", "u", "v"}},
        {'9', new() {"w", "x", "y", "z"}},
    };

    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (digits.Length > 0)
        {
            BackTrack(digits, 0, result, "");
        }
        return result;
    }

    private void BackTrack(string digits, 
        int index, 
        List<string> result, 
        string currentCombination)
    {
        if (currentCombination.Length == digits.Length)
        {
            result.Add(currentCombination);
            return;
        }

        var characters = _map[digits[index]];

        for (int i = 0; i < characters.Count; i++)
        {
            currentCombination += characters[i];
            BackTrack(digits, index + 1, result, currentCombination);
            currentCombination = currentCombination.Substring(0, currentCombination.Length - 1);
        }
    }
}

```

### Complexity

- **Time complexity**:
The time complexity is $O(4^N)$ in the worst case, where $N$ is the length of the input string, since the maximum number of letters per digit is 4 (for digit 7 and 9).
- **Space complexity**:
The space complexity is $O(N)$ for the recursion stack and the storage of the result.

## 39. [Combination Sum](https://leetcode.com/problems/combination-sum)

### Intuition

The problem involves finding all possible combinations of numbers from the `candidates` array that sum up to the given `target`. Since the same number can be used multiple times, a backtracking approach seems suitable for exploring all potential combinations.

### Approach

- **Backtracking**: We utilize a backtracking technique to explore combinations. We maintain a `currentCombination` list to build combinations incrementally.
- **Base Cases**: If the `currentSum` equals the `target`, we add a copy of `currentCombination` to the `result`. If `currentSum` exceeds `target`, we return to avoid unnecessary calculations.
- **Recursion**: We iterate through the `candidates`, adding each candidate to the `currentCombination`, and recursively call the `BackTrack` method with the updated sum and starting index.
- **Backtrack**: After exploring one path, we remove the last added candidate to backtrack and try the next candidate.

### Code

```csharp
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new();
        List<int> currentCombination = new();
        BackTrack(candidates, 0, target, 0, currentCombination, result);
        return result;
    }

    private static void BackTrack(
        int[] candidates, 
        int start, 
        int target, 
        int currentSum, 
        List<int> currentCombination, 
        List<IList<int>> result)
    {
        if (currentSum == target)
        {
            result.Add(new List<int>(currentCombination));
            return;
        }

        if (currentSum > target) return;

        for (int i = start; i < candidates.Length; i++)
        {
            currentCombination.Add(candidates[i]);
            BackTrack(candidates, i, target, currentSum + candidates[i], currentCombination, result);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}
```

### Complexity

- **Time complexity**:
The time complexity is not straightforward to define as it depends on the number of valid combinations, but it can be considered as $O(2^{N})$ in the worst case due to the exponential growth of possible combinations.
- **Space complexity**:
The space complexity is $O(N)$ for the recursion stack and the storage of the result, where $N$ is the length of the candidates array.

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

---

## 78. [Subsets](https://leetcode.com/problems/subsets)

### 1. **Cascading Approach:**

The **Cascading** approach progressively builds the list of subsets by adding each element of the input array (`nums`) to existing subsets. Here's how it works:

- **Initial Setup**: The algorithm starts with an empty subset (`solutionList`) that initially contains one subset: the empty list `[]`.
- **Iteration**: It iterates through each number in the input array `nums`. For every number, it creates new subsets by adding the current number to each of the existing subsets in `solutionList`.
- **Local List**: A temporary list (`localSolutionList`) is used to hold these new subsets during each iteration.
- **Extend Solutions**: After processing all existing subsets for the current number, the `localSolutionList` (which contains all newly generated subsets) is appended to the main `solutionList`.
- **Result**: Once all numbers are processed, `solutionList` contains all possible subsets of the input array.

Here is the code implementation:

```csharp
private IList<IList<int>> Subsets(int[] nums)
{
    var solutionList = new List<IList<int>> { new List<int>() };  // Start with the empty set

    foreach (int number in nums)
    {
        List<IList<int>> localSolutionList = new();
        foreach (var solution in solutionList)
        {
            var newSolution = solution.ToList();
            newSolution.Add(number);
            localSolutionList.Add(newSolution);
        }
        solutionList.AddRange(localSolutionList);
    }
    return solutionList;
}

```

**Time Complexity**:

- In each iteration, for every new number, we generate new subsets based on the current size of the `solutionList`. Initially, there is 1 subset (the empty set), then 2, then 4, and so on.
- The number of subsets at each step doubles, and generating a subset involves copying an existing subset, which takes $O(k)$ time, where $k$ is the length of the subset.
- Therefore, the time complexity is $O(N * 2^N)$, where `N` is the number of elements in the input array `nums`.

**Space Complexity**:

- The space complexity is $O(N * 2^N)$, as we are storing all the subsets, and there are $2^N$ subsets in total, each of size up to `N`.

---

### 2. **Backtracking Approach:**

The **Backtracking** approach is a recursive method that explores all possible subsets by making choices and undoing them (backtracking) when necessary. Here's how it works:

- **Initial Call**: The algorithm starts by calling the recursive function `BackTrack` with the initial values: an empty list (`current`), the starting index (`start`), and the full length of the input array.
- **Recursive Exploration**: At each recursive step, the current subset (`current`) is added to the `result` list. Then, the function tries adding each number in the array (starting from the current index `start`) to the `current` subset.
- **Backtracking**: After adding a number, it recurses deeper to explore further possible subsets. When a recursion finishes, the function **backtracks** by removing the last added number from the subset, ensuring all combinations are explored.
- **Result**: The base case is when the recursion has explored all subsets for the current state, at which point it returns back up the call stack. This way, the `result` list eventually contains all possible subsets.

Here is the code implementation:

```csharp
private IList<IList<int>> Subsets(int[] nums)
{
    List<IList<int>> result = new List<IList<int>>();
    List<int> current = new List<int>();
    BackTrack(nums, 0, nums.Length, current, result);
    return result;
}

private void BackTrack(int[] nums, int start, int len, List<int> current, IList<IList<int>> result)
{
    result.Add(current.ToArray());  // Add the current subset to the result list

    for (int i = start; i < len; i++)
    {
		    // Choose the current element
        current.Add(nums[i]); 
        // Recurse to explore further subsets
        BackTrack(nums, i + 1, len, current, result);
        // Backtrack by removing the last element
        current.RemoveAt(current.Count - 1);
    }
}

```

**Time Complexity**:

- The time complexity is $O(N * 2^N)$. Here's why:
    - There are $2^N$ possible subsets (since each element is either included or not).
    - For each subset, we make a copy of the `current` list, which can take up to $O(N)$ time. Therefore, the total time complexity is $O(N * 2^N)$.

**Space Complexity**:

- The space complexity is also $O(N * 2^N)$, as we store all $2^N$ subsets, each of which can be up to size `N`. Additionally, the recursion call stack can go as deep as `N` levels, so the overall space complexity is dominated by the result storage.

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
