# 104. [Maximum Depth of Binary Tree](https://leetcode.com/problems/maximum-depth-of-binary-tree)

```C#
public int MaxDepth(TreeNode node)
{
    if(node == null) return 0;

    var leftMaxDepth = MaxDepth(node.left);
    var rightMaxDepth = MaxDepth(node.right);

    return Math.Max(leftMaxDepth, rightMaxDepth) + 1; // +1 for current node;
}
```

The algorithm used in this solution is **Depth-First Search (DFS)**.

This solution uses a recursive approach to find the maximum depth of a binary tree.

- **Base Case:** If the current node is null, the depth is 0.
Recursive Case: The function calculates the depth of the left and right subtrees, then returns the maximum of the two, plus 1 for the current node.
- **Final Result:** The maximum depth of the tree is built up from the leaf nodes to the root, with each level adding 1 to the depth.
- This approach ensures that all nodes are visited, leading to an overall time complexity of O(n). Space complexity of O(n) due to recursion stack use.