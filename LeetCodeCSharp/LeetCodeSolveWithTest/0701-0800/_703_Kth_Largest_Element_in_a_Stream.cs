using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._0701_0800
{
    public class _703_Kth_Largest_Element_in_a_Stream
    {
        public class KthLargest
        {
            private PriorityQueue<int, int> priorityQueue = new();
            private int maxSize;
            public KthLargest(int k, int[] nums)
            {
                maxSize = k;
                foreach (int num in nums)
                {
                    priorityQueue.Enqueue(num, num);
                    if (priorityQueue.Count > k)
                        priorityQueue.Dequeue();
                }
            }

            public int Add(int val)
            {
                if (priorityQueue.Count < maxSize || val > priorityQueue.Peek())
                    priorityQueue.Enqueue(val, val);

                if (priorityQueue.Count > maxSize)
                    priorityQueue.Dequeue();

                return priorityQueue.Peek();
            }
        }

        [Theory]
        [InlineData(new int[] { 4, 5, 8, 2 }, 3, new int[] { 3, 5, 10, 9, 4 }, new int[] { 4, 5, 5, 8, 8 })]
        [InlineData(new int[] { 7, 7, 7, 7, 8, 3 }, 4, new int[] { 2, 10, 9, 9 }, new int[] { 7, 7, 7, 8 })]
        [InlineData(new int[] { }, 1, new int[] { -3, -2, -4, 0, 4 }, new int[] { -3, -2, -2, 0, 4 })]
        public void _703_Kth_Largest_Element_in_a_Stream_Test(int[] nums, int k, int[] addVals, int[] expected)
        {
            // Arrange
            var sut = new KthLargest(k, nums);

            // Act & Assert
            for (int i = 0; i < addVals.Length; i++)
            {
                var result = sut.Add(addVals[i]);
                Assert.Equal(expected[i], result);
            }
        }
    }
}
