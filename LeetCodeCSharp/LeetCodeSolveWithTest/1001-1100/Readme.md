# 1046. [Last Stone Weight](https://leetcode.com/problems/last-stone-weight)

## Intuition

The idea is to always smash the two largest stones together. If the stones are of equal weight, both stones are destroyed. If they are of unequal weight, the smaller stone is destroyed, and the larger stone is reduced by the smaller stone's weight. This process continues until only one stone remains or no stones are left.

The most efficient way to keep track of the largest stones is to use a max-heap (priority queue). We can repeatedly extract the two largest stones, compute the result of their collision, and put the remainder (if any) back into the heap.

## Approach

1. Use a **priority queue** (max-heap) to always access the two largest stones.
2. Insert all stones into the priority queue, but negate their values since the default priority queue in C# is a min-heap.
3. Repeatedly remove the two largest stones and compute their difference:
   - If the stones are of equal weight, both are destroyed.
   - If they are unequal, the remainder (difference) is added back to the queue.
4. When there is only one stone or no stones left, return the weight of the last stone (or `0` if no stones remain).

## Code

```csharp
public class Solution {
    public int LastStoneWeight(int[] stones)
    {
        // Create a priority queue and add all stones (negated for max-heap)
        PriorityQueue<int, int> priorityQueue = new();
        foreach (int stone in stones)
            priorityQueue.Enqueue(stone, -stone);

        // Continue until one or no stones are left
        while (priorityQueue.Count > 1)
        {
            // Remove the two largest stones
            var largest = priorityQueue.Dequeue();
            var secondLargest = priorityQueue.Dequeue();

            // If they are not equal, enqueue the difference back
            if (largest != secondLargest)
            {
                var diff = largest - secondLargest;
                priorityQueue.Enqueue(diff, -diff);
            }
        }

        // Return the weight of the last stone, or 0 if none are left
        if (priorityQueue.Count > 0)
            return priorityQueue.Dequeue();
        else
            return 0;
    }
}
```

## Complexity

- **Time complexity**:
  The time complexity is $O(n \log n)$, where $n$ is the number of stones. This is because each stone is added to the priority queue, and each operation (insertion or deletion) in a heap takes $O(\log n)$. In the worst case, we might need to perform $n$ operations.

- **Space complexity**:  
  The space complexity is $O(n)$, since we are storing all the stones in the priority queue.