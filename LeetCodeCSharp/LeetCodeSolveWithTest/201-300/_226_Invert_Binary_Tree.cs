namespace LeetCodeSolveWithTest._201_300
{
    public class _226_Invert_Binary_Tree
    {
        private class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private TreeNode InvertTree(TreeNode root)
        {
            if(root == null)
                return null;

            var temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);
            
            return root;
        }

        [Theory]
        [InlineData((int[])[4, 2, 7, 1, 3, 6, 9], (int[])[4, 7, 2, 9, 6, 3, 1])]
        [InlineData((int[])[2, 1, 3], (int[])[2, 3, 1])]
        [InlineData((int[])[], (int[])[])]
        public void _226_Invert_Binary_Tree_Test(int[] values, int[] expected)
        {
            // Arrange
            var sut = InvertTree;
            TreeNode? root = CreateTreeFromLevelOrder(values);

            // Act
            var result = sut(root);

            // Assert
            var levelOrderTraversalOutput = LevelOrderTraversal(result);
            Assert.Equal(expected, levelOrderTraversalOutput);
        }

        private static TreeNode? CreateTreeFromLevelOrder(int[] array, int startIndex = 0)
        {
            if (array.Length == 0)
                return null;
            var currentNode = new TreeNode(array[startIndex]);

            var leftIndex = 2 * startIndex + 1;
            var rightIndex = 2 * startIndex + 2;

            if (leftIndex < array.Length)
            {
                currentNode.left = CreateTreeFromLevelOrder(array, leftIndex);
            }

            if (rightIndex < array.Length)
            {
                currentNode.right = CreateTreeFromLevelOrder(array, rightIndex);
            }

            return currentNode;
        }

        private int[] LevelOrderTraversal(TreeNode? root)
        {
            var queue = new Queue<TreeNode?>();
            List<int> values = new();
            queue.Enqueue(root);
            queue.Enqueue(null);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if(node != null)
                {
                    values.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return values.ToArray();
        }
    }
}
