# 543. [Diameter of Binary Tree](https://leetcode.com/problems/diameter-of-binary-tree)

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

## Approach 1

Answer can be in 3 options:

1. Ans in left sub tree.
2. Ans in right sub tree.
3. Ans in combination of left and right subtree.

- option 1: `diameter(leftSubTree)`
- option 2: `diameter(rightSubTree)`
- option 3: `height(leftSubTree) + height(leftSubTree)`
- full tree diameter: Max of all options.
