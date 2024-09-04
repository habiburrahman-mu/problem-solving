using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._001_100
{
    public class _100_Same_Tree
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

        private bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            var isValueSame = p.val == q.val;
            if (!isValueSame) return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new int?[] { 1, 2, 3 }, new int?[] { 1, 2, 3 }, true };
            yield return new object[] { new int?[] { 1, 2 }, new int?[] { 1, null, 2 }, false };
            yield return new object[] { new int?[] { 1, 2, 1 }, new int?[] { 1, 1, 2 }, false };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void _110_Balanced_Binary_Tree_Test(int?[] p, int?[] q, bool expected)
        {
            // Arrange
            var sut = IsSameTree;
            TreeNode? pRoot = CreateTreeFromLevelOrder(p);
            TreeNode? qRoot = CreateTreeFromLevelOrder(q);

            // Act
            var result = sut(pRoot, qRoot);

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
