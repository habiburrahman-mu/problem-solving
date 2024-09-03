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

# 110. [Balanced Binary Tree](https://leetcode.com/problems/balanced-binary-tree)

## Approach 1

- check balance status for node.
  - Calculate height of the left sub tree and right sub tree.
  - If $h_{left} - h_{right} > 1$ not balanced.
- check the balance status of left and right sub tree by *recursion*.
- return true if all check pass.

```C#
public bool IsBalanced(TreeNode root)
{
    if(root == null) return true;
    
    var leftHeight = Height(root.left);
    var rightHeight = Height(root.right);
    if(Math.Abs(leftHeight-rightHeight) > 1) return false;

    if (!IsBalanced(root.left)) return false;
    if (!IsBalanced(root.right)) return false;

    return true;
}

private int Height(TreeNode node)
{
    if (node == null) return 0;

    var leftHeight = Height(node.left);
    var rightHeight = Height(node.right);

    return Math.Max(leftHeight, rightHeight) + 1;
}
```

## Complexities

- **Time Complexity:** $O(N^2)$, where $N$ = number of nodes.
- **Space Complexity:** $O(H)$, where $H$ = Height of tree.

The `IsBalanced` method checks whether a binary tree is balanced by comparing the heights of its left and right subtrees at each node. It does this by recursively calculating the height of the left and right subtrees using the `Height` method.

- **Time Complexity:** The `Height` method, which is called for each node, has a time complexity of `O(N)`, where `N` is the number of nodes in the subtree. Since `IsBalanced` calls `Height` for every node in the tree, the overall time complexity of `IsBalanced` is `O(N^2)` in the worst case.
- **Space Complexity:** The space complexity is determined by the depth of the recursion stack. In the worst case (a completely unbalanced tree), the space complexity is `O(N)`.

In summary, the `IsBalanced` method is not very efficient for large trees due to its `O(N^2)` time complexity, primarily caused by the repeated calculations of subtree heights.

## Approach 2

- do not calculate the height again and again.
- reuse it by returning it while checking the balance status.

```C#
public bool IsBalanced(TreeNode root)
{
    return HeightAndBalanceStatus(root).isBalanced;
}

private (int height, bool isBalanced) HeightAndBalanceStatus(TreeNode root)
{
    if (root == null) return (0, true);

    var (leftHeight, leftBalanced) = HeightAndBalanceStatus(root.left);
    var (rightHeight, rightBalanced) = HeightAndBalanceStatus(root.right);

    var height = Math.Max(leftHeight, rightHeight) + 1;

    if(!leftBalanced || !rightBalanced) return (height, false);
    if (Math.Abs(leftHeight - rightHeight) > 1) return (height, false);

    return (height, true);
}
```

## Complexities

- **Time Complexity**: O(n) (linear time, as each node is visited only once)
- **Space Complexity**: O(n) (due to the recursion stack in the worst case)
