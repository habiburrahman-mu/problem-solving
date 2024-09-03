using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._101_200
{
    public class _110_Balanced_Binary_Tree
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

        private bool IsBalanced(TreeNode root)
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

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new int?[] { 3, 9, 20, null, null, 15, 7 }, true };
            yield return new object[] { new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }, false };
            yield return new object[] { new int?[] { }, true };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void _110_Balanced_Binary_Tree_Test(int?[] values, bool expected)
        {
            // Arrange
            var sut = IsBalanced;
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
