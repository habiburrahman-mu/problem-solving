using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._501_600
{
    public class _572_Subtree_of_Another_Tree
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

        private bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null) return true;
            if (root != null && subRoot == null) return true;
            if (root == null && subRoot != null) return false;

            if (root.val == subRoot.val)
            {
                if (IsSameTree(root, subRoot))
                    return true;
            }

            if (IsSubtree(root.left, subRoot))
                return true;
            if (IsSubtree(root.right, subRoot))
                return true;

            return false;
        }

        private bool IsSameTree(TreeNode node, TreeNode subTree)
        {
            if (node == null && subTree == null) return true;
            if (node == null && subTree != null) return false;
            if (node != null && subTree == null) return false;

            if (node.val != subTree.val) return false;
            return IsSameTree(node.left, subTree.left) && IsSameTree(node.right, subTree.right);
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new int?[] { 3, 4, 5, 1, 2 }, new int?[] { 4, 1, 2 }, true };
            yield return new object[] { new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 }, new int?[] { 4, 1, 2 }, false };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void _110_Balanced_Binary_Tree_Test(int?[] root, int?[] subRoot, bool expected)
        {
            // Arrange
            var sut = IsSubtree;
            TreeNode? rootTree = CreateTreeFromLevelOrder(root);
            TreeNode? subRootTree = CreateTreeFromLevelOrder(subRoot);

            // Act
            var result = sut(rootTree, subRootTree);

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
