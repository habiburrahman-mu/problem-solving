# 543. [Diameter of Binary Tree](https://leetcode.com/problems/diameter-of-binary-tree)

## Approach 1

```C#
public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null) return 0;

        var leftTreeDiameter = DiameterOfBinaryTree(root.left);
        var rightTreeDiameter = DiameterOfBinaryTree(root.right);
        var diameterWithNode = HeightOfBinaryTree(root.left) + HeightOfBinaryTree(root.right);
        return Math.Max(diameterWithNode, Math.Max(leftTreeDiameter, rightTreeDiameter));
    }

    private int HeightOfBinaryTree(TreeNode node)
    {
        if (node == null) return 0;

        var leftTreeHeight = HeightOfBinaryTree(node.left);
        var rightTreeHeight = HeightOfBinaryTree(node.right);
        return Math.Max(leftTreeHeight, rightTreeHeight) + 1;
    }
```

Answer can be in 3 options:

1. Ans in left sub tree.
2. Ans in right sub tree.
3. Ans in combination of left and right subtree.

- option 1: `diameter(leftSubTree)`
- option 2: `diameter(rightSubTree)`
- option 3: `height(leftSubTree) + height(leftSubTree)`
- full tree diameter: Max of all options.

**Time Complexity:** $O(N^2)$, $N$ = Number of nodes

## Approach 2

```C#
public int DiameterOfBinaryTree(TreeNode root)
    {
        return DiameterAndHeight(root).diameter;
    }

    private (int diameter, int height) DiameterAndHeight(TreeNode root)
    {
        if (root == null) return (0, 0);

        var (leftTreeDiameter, leftTreeHeight) = DiameterAndHeight(root.left);
        var (rightTreeDiameter, rightTreeHeight) = DiameterAndHeight(root.right);
        var diameterWithNode = leftTreeHeight + rightTreeHeight;

        var height = Math.Max(leftTreeHeight, rightTreeHeight) + 1;
        var diameter = Math.Max(diameterWithNode, Math.Max(leftTreeDiameter, rightTreeDiameter));

        return (diameter, height);
    }
```

- The problem with the previous solution was that it was calculating the height repeatedly. Just return the height and it will minimize the overhead.

**Time Complexity:** $O(N)$, $N$ = Number of nodes

**Space Complexity:** $O(H)$, $H$ = Height of the tree which may the number of nodes due to skewed tree height.

# 572. [Subtree of Another Tree](https://leetcode.com/problems/subtree-of-another-tree)

## Intuition

The problem requires us to determine if one tree (`subRoot`) is a subtree of another (`root`). The key idea is to traverse the main tree and whenever we find a node that matches the root of `subRoot`, we check if the subtree rooted at that node is identical to `subRoot`.

## Approach

1. **Base Cases**:
   - If both `root` and `subRoot` are `null`, they are trivially identical, so return `true`.
   - If `root` is not `null` and `subRoot` is `null`, return `true` because an empty tree is a subtree of any tree.
   - If `root` is `null` and `subRoot` is not `null`, return `false` because a non-empty tree cannot be a subtree of an empty tree.

2. **Recursive Check**:
   - If the value of the current node in `root` matches the value of `subRoot`, invoke `IsSameTree` to check if the trees rooted at these nodes are identical.
   - If they are identical, return `true`.
   - Otherwise, recursively check the left and right subtrees of `root` to see if `subRoot` is a subtree of either.

3. **Helper Function (`IsSameTree`)**:
   - This function checks whether two trees are identical by comparing each node and its children recursively.

## Complexity

- **Time complexity:**  
  The time complexity is $O(m \times n)$, where `m` is the number of nodes in the `root` tree and `n` is the number of nodes in the `subRoot` tree. In the worst case, we might compare `subRoot` with every subtree of `root`.

- **Space complexity:**  
  The space complexity is $O(h)$, where `h` is the height of the `root` tree. This is the space used by the recursion stack. In the worst case (skewed tree), it could be $O(m)$.

## Code

```csharp
public class Solution {
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        // If both trees are null, subRoot is trivially a subtree of root
        if (root == null && subRoot == null) return true;

        // If subRoot is null, it is a subtree of any non-null tree
        if (root != null && subRoot == null) return true;

        // If root is null and subRoot is not, subRoot cannot be a subtree
        if (root == null && subRoot != null) return false;

        // Check if the current trees rooted at root and subRoot are identical
        if (root.val == subRoot.val)
        {
            if (IsSameTree(root, subRoot))
                return true;
        }

        // Recursively check if subRoot is a subtree of either the left or right subtree of root
        if (IsSubtree(root.left, subRoot))
            return true;
        if (IsSubtree(root.right, subRoot))
            return true;

        // If no match was found, return false
        return false;
    }

    // Helper function to check if two trees are identical
    private bool IsSameTree(TreeNode node, TreeNode subTree)
    {
        // If both nodes are null, the trees are identical
        if (node == null && subTree == null) return true;

        // If one node is null and the other is not, the trees are not identical
        if (node == null && subTree != null) return false;
        if (node != null && subTree == null) return false;

        // If the values of the current nodes are different, the trees are not identical
        if (node.val != subTree.val) return false;

        // Recursively check the left and right subtrees
        return IsSameTree(node.left, subTree.left) && IsSameTree(node.right, subTree.right);
    }
}
```
