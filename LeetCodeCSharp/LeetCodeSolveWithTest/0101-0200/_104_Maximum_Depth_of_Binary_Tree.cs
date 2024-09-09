namespace LeetCodeSolveWithTest._101_200
{
    public class _104_Maximum_Depth_of_Binary_Tree
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

        private int MaxDepth(TreeNode node)
        {
            if(node == null) return 0;

            var leftMaxDepth = MaxDepth(node.left);
            var rightMaxDepth = MaxDepth(node.right);

            return Math.Max(leftMaxDepth, rightMaxDepth) + 1; // +1 for current node;
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new int?[] { 3, 9, 20, null, null, 15, 7 }, 3 };
            yield return new object[] { new int?[] { 1, null, 2 }, 2 };
            yield return new object[] { new int?[] { }, 0 };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void _104_Maximum_Depth_of_Binary_Tree_Test(int?[] values, int expected)
        {
            // Arrange
            var sut = MaxDepth;
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
