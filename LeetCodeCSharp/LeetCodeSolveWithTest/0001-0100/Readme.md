# 100. [Same Tree](https://leetcode.com/problems/same-tree)

## Intuition

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
