using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._501_600
{
    public class _543_Diameter_of_Binary_Tree
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

        private int DiameterOfBinaryTree(TreeNode root)
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

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new int?[] { 1, 2, 3, 4, 5 }, 3 };
            yield return new object[] { new int?[] { 1, 2 }, 1 };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void _104_Maximum_Depth_of_Binary_Tree_Test(int?[] values, int expected)
        {
            // Arrange
            var sut = DiameterOfBinaryTree;
            TreeNode? root = CreateTreeFromLevelOrder(values);

            // Act
            var result = sut(root);

            // Assert
            Assert.Equal(expected, result);
        }

        private static TreeNode? CreateTreeFromLevelOrder(int?[] array, int startIndex = 0)
        {
            if (array.Length == 0 || array[startIndex].HasValue == false)
                return null;
            var value = array[startIndex];
            if (value == null)
                return null;

            var currentNode = new TreeNode(value.Value);

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
    }
}
