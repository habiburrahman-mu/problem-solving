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
