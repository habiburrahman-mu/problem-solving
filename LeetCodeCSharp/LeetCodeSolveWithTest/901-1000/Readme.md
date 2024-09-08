# 912. [Sort an Array](https://leetcode.com/problems/sort-an-array)

## Approach 1

### Intuition

Heap sort is an efficient, comparison-based sorting algorithm that uses a binary heap structure. The key idea is to build a max-heap from the array and then extract the maximum element (the root of the heap) one by one, placing it at the end of the array.

### Approach

1. **Building a Max Heap**: The algorithm starts by transforming the input array into a max heap. A max heap is a binary tree where the root node is always larger than its children, and this property is recursively true for all subtrees.

    ```console
          5
        /   \
       2     3
      /
     1
    ```

2. **Heap Sorting**: Once the array is turned into a max heap, we repeatedly swap the root of the heap (the maximum value) with the last element in the array. Then, the heap size is reduced by one, and the heap is restructured to maintain the max-heap property. This process continues until the heap is reduced to size 1, leaving the array sorted.

### Code

```csharp
public class Solution {
    public int[] SortArray(int[] nums)
    {
        // Build a max heap from the input array
        BuildMaxHeap(nums);
        // Sort the array using heap sort
        HeapSort(nums);
        return nums;
    }

    // Function to build the max heap
    private void BuildMaxHeap(int[] nums)
    {
        int length = nums.Length;
        // Start heapifying from the last non-leaf node down to the root
        for (int i = length / 2; i >= 0; i--)
        {
            MaxHeapify(nums, i, length);
        }
    }

    // Function to maintain the max heap property for the current node
    private void MaxHeapify(int[] nums, int index, int sizeToConsider)
    {
        int largest = index; // Assume the current index is the largest
        int left = 2 * index + 1; // Left child
        int right = 2 * index + 2; // Right child

        // Check if the left child exists and is larger than the current largest
        if (left < sizeToConsider && nums[left] > nums[largest])
            largest = left;

        // Check if the right child exists and is larger than the current largest
        if (right < sizeToConsider && nums[right] > nums[largest])
            largest = right;

        // If the largest value has changed, swap and continue heapifying
        if (largest != index)
        {
            int tmp = nums[largest];
            nums[largest] = nums[index];
            nums[index] = tmp;

            // Recursively heapify the affected subtree
            MaxHeapify(nums, largest, sizeToConsider);
        }
    }

    // Function to perform heap sort
    private void HeapSort(int[] nums)
    {
        int stoppingIndex = nums.Length - 1;

        // Continue until the entire array is sorted
        while (stoppingIndex > 0)
        {
            // Swap the root of the heap (the max element) with the last element
            var tmp = nums[stoppingIndex];
            nums[stoppingIndex] = nums[0];
            nums[0] = tmp;

            // Decrease the size of the heap
            stoppingIndex--;

            // Heapify the reduced heap
            MaxHeapify(nums, 0, stoppingIndex + 1);
        }
    }
}

```

### Complexity

#### Time Complexity Analysis

- **Building the Max Heap**: While it may seem like heapifying each node could take $O(\log⁡ n)$ time (as that's the cost of heapifying an individual element), building the max heap overall actually takes $O(n)$ time. This is because:
  - Most of the heapify operations occur on nodes closer to the leaves, which take significantly less time to heapify.
  - More specifically, the nodes in the lower levels of the tree (closer to the leaves) require fewer comparisons during heapification. The higher up in the tree, the fewer nodes there are to heapify, even though those nodes may require more comparisons.
- **Heap Sort (repeated extraction and heapify)**: Once the heap is built, we repeatedly remove the maximum element (the root) and re-heapify the reduced heap. This step is where each removal and heapify operation costs $O(\log n)$, and we do this nnn times, leading to $O(n \log n)$ for the sorting phase.

Thus, the overall **time complexity** is:

- Building the heap: $O(n)$  
- Heap sort (extraction + heapify): $O(n \log n)$
- Total: $O(n + n \log n)$ = $O(n \log n)$

#### Space Complexity Analysis

- **Auxiliary space**: `MaxHeapify` function uses recursion. The depth of recursion will depend on the height of the tree, which is $O(\log n)$ for a binary heap. Thus, the space complexity is determined by the recursion depth. $O(\log n)$

- There is no extra storage allocated for the array, so aside from the recursion stack, we are working in-place.

Thus, the **space complexity** is:

- **Space complexity**: $O(\log n)$ due to the recursion in `MaxHeapify`.
