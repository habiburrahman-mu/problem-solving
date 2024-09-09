using LeetCodeSolveWithTest._001_100;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._901_1000
{
    public class _912_Sort_an_Array
    {
        private int[] SortArray(int[] nums)
        {
            BuildMaxHeap(nums);
            HeapSort(nums);
            return nums;
        }

        private void BuildMaxHeap(int[] nums)
        {
            int length = nums.Length;
            for (int i = length / 2; i >= 0; i--)
            {
                MaxHeapify(nums, i, length);
            }
        }

        private void MaxHeapify(int[] nums, int index, int sizeToConsider)
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < sizeToConsider && nums[left] > nums[largest])
                largest = left;
            if (right < sizeToConsider && nums[right] > nums[largest])
                largest = right;
            if (largest != index)
            {
                int tmp = nums[largest];
                nums[largest] = nums[index];
                nums[index] = tmp;

                MaxHeapify(nums, largest, sizeToConsider);
            }
            return;
        }

        private void HeapSort(int[] nums)
        {
            int stoppingIndex = nums.Length - 1;
            while (stoppingIndex > 0)
            {
                // swap
                var tmp = nums[stoppingIndex];
                nums[stoppingIndex] = nums[0];
                nums[0] = tmp;

                stoppingIndex--;

                // Heapify
                MaxHeapify(nums, 0, stoppingIndex + 1);
            }
        }

        [Theory]
        [InlineData((int[])[5, 2, 3, 1], (int[])[1, 2, 3, 5])]
        [InlineData((int[])[5, 1, 1, 2, 0, 0], (int[])[0, 0, 1, 1, 2, 5])]
        public void _206_Reverse_Linked_List_Test(int[] nums, int[] expected)
        {
            // Arrange
            var sut = SortArray;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
