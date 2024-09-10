# 703. [Kth Largest Element in a Stream](https://leetcode.com/problems/kth-largest-element-in-a-stream)

## Intuition

The task is to maintain the Kth largest element in a dynamically updated stream of numbers. Since we want the Kth largest element, the first intuition is to use a min-heap (priority queue) to maintain only the largest `k` elements. The smallest element in this heap will represent the Kth largest element.

## Approach

1. Use a **priority queue** (min-heap) to store the largest `k` elements.
2. Initialize the priority queue with the elements in the array `nums`. As we add new elements, we ensure that the size of the heap never exceeds `k`.
3. Each time a new element is added, if it is larger than the smallest element in the heap (i.e., the root of the heap), we add it to the heap. If the heap exceeds `k` elements, we remove the smallest (root) element.
4. The Kth largest element will always be the root of the heap, as it represents the smallest element in the heap of size `k`.

## Code

```csharp
public class KthLargest
{
    private PriorityQueue<int, int> priorityQueue = new();
    private int maxSize;

    public KthLargest(int k, int[] nums)
    {
        maxSize = k;
        foreach (int num in nums)
            Add(num);
    }

    public int Add(int val)
    {
        // Add new value if the heap is not full or the value is larger than the current kth largest
        if (priorityQueue.Count < maxSize || val > priorityQueue.Peek())
            priorityQueue.Enqueue(val, val); // Enqueue the value with its priority being the value itself

        // If the heap exceeds max size (k), remove the smallest element
        if (priorityQueue.Count > maxSize)
            priorityQueue.Dequeue();

        // The root of the heap (smallest in the heap of k largest elements) is the kth largest
        return priorityQueue.Peek();
    }
}
```

## Complexity

- **Time complexity**:  
  The time complexity for each `Add` operation is $O(\log k)$, where $k$ is the number of elements we are keeping in the priority queue. This is because both insertion and deletion operations in a heap take logarithmic time relative to the heap size, and the heap is limited to `k` elements. Therefore, initializing the heap takes $O(n \log k)$ where $n$ is the number of elements in the initial array `nums`.

- **Space complexity**:  
  The space complexity is $O(k)$, since we are storing at most `k` elements in the priority queue at any time.
