namespace LeetCodeSolveWithTest._201_300
{
    public class _215_Kth_Largest_Element_in_an_Array
    {
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> priorityQueue = new();
            for (int i = 0; i < nums.Length; i++)
                priorityQueue.Enqueue(nums[i], -nums[i]); // for descending sort

            for (int i = 0; i < k - 1; i++)
                priorityQueue.Dequeue();

            return priorityQueue.Dequeue();
        }

        [Theory]
        [InlineData((int[])[3, 2, 1, 5, 6, 4], 2, 5)]
        [InlineData((int[])[3, 2, 3, 1, 2, 4, 5, 5, 6], 4, 4)]
        public void _206_Reverse_Linked_List_Test(int[] nums, int k, int expected)
        {
            // Arrange
            var sut = FindKthLargest;

            // Act
            var result = sut(nums, k);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
