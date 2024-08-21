namespace LeetCodeSolveWithTest._201_300
{

    public class _206_Reverse_Linked_List
    {
        private class ListNode
        {
            public int val;
            public ListNode? next;
            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private ListNode ReverseList(ListNode head)
        {
            return new ListNode();
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new int[] { 1, 2 }, new[] { 2, 1 })]
        [InlineData(new int[] { }, new int[] { })]
        public void _206_Reverse_Linked_List_Test(int[] head, int[] expected)
        {
            // Arrange
            var sut = ReverseList;
            ListNode? listNode1 = BuildLinkedList(head);

            // Act
            var result = sut(listNode1);

            // Assert
            Assert.Equal(expected, ConvertLinkedListToArray(result));
        }

        private ListNode? BuildLinkedList(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            var head = new ListNode(values[0]);
            var current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        private int[] ConvertLinkedListToArray(ListNode? head)
        {
            List<int> resultedList = new();
            var current = head;

            while (current != null)
            {
                resultedList.Add(current.val);
                current = current.next;
            }
            return resultedList.ToArray();
        }
    }


}
