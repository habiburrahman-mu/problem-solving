namespace LeetCodeSolveWithTest._001_100
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class _021_MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummyHead = new(-1);
            ListNode current = dummyHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            current.next = list1 ?? list2;

            return dummyHead.next;
        }

        [Theory]
        [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new[] { 0 }, new[] { 0 })]
        public void _021_MergeTwoSortedLists_Test(int[] list1, int[] list2, int[] expected)
        {
            // Arrange
            var sut = MergeTwoLists;
            ListNode? listNode1 = BuildLinkedList(list1);
            ListNode? listNode2 = BuildLinkedList(list2);

            // Act
            var result = sut(listNode1, listNode2);

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
