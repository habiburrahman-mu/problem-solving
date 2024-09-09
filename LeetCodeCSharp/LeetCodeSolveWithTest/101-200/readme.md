# 104. [Maximum Depth of Binary Tree](https://leetcode.com/problems/maximum-depth-of-binary-tree)

```C#
public int MaxDepth(TreeNode node)
{
    if(node == null) return 0;

    var leftMaxDepth = MaxDepth(node.left);
    var rightMaxDepth = MaxDepth(node.right);

    return Math.Max(leftMaxDepth, rightMaxDepth) + 1; // +1 for current node;
}
```

The algorithm used in this solution is **Depth-First Search (DFS)**.

This solution uses a recursive approach to find the maximum depth of a binary tree.

- **Base Case:** If the current node is null, the depth is 0.
Recursive Case: The function calculates the depth of the left and right subtrees, then returns the maximum of the two, plus 1 for the current node.
- **Final Result:** The maximum depth of the tree is built up from the leaf nodes to the root, with each level adding 1 to the depth.
- This approach ensures that all nodes are visited, leading to an overall time complexity of O(n). Space complexity of O(n) due to recursion stack use.

# 110. [Balanced Binary Tree](https://leetcode.com/problems/balanced-binary-tree)

## Approach 1

- check balance status for node.
  - Calculate height of the left sub tree and right sub tree.
  - If $h_{left} - h_{right} > 1$ not balanced.
- check the balance status of left and right sub tree by *recursion*.
- return true if all check pass.

```C#
public bool IsBalanced(TreeNode root)
{
    if(root == null) return true;
    
    var leftHeight = Height(root.left);
    var rightHeight = Height(root.right);
    if(Math.Abs(leftHeight-rightHeight) > 1) return false;

    if (!IsBalanced(root.left)) return false;
    if (!IsBalanced(root.right)) return false;

    return true;
}

private int Height(TreeNode node)
{
    if (node == null) return 0;

    var leftHeight = Height(node.left);
    var rightHeight = Height(node.right);

    return Math.Max(leftHeight, rightHeight) + 1;
}
```

## Complexities

- **Time Complexity:** $O(N^2)$, where $N$ = number of nodes.
- **Space Complexity:** $O(H)$, where $H$ = Height of tree.

The `IsBalanced` method checks whether a binary tree is balanced by comparing the heights of its left and right subtrees at each node. It does this by recursively calculating the height of the left and right subtrees using the `Height` method.

- **Time Complexity:** The `Height` method, which is called for each node, has a time complexity of `O(N)`, where `N` is the number of nodes in the subtree. Since `IsBalanced` calls `Height` for every node in the tree, the overall time complexity of `IsBalanced` is `O(N^2)` in the worst case.
- **Space Complexity:** The space complexity is determined by the depth of the recursion stack. In the worst case (a completely unbalanced tree), the space complexity is `O(N)`.

In summary, the `IsBalanced` method is not very efficient for large trees due to its `O(N^2)` time complexity, primarily caused by the repeated calculations of subtree heights.

## Approach 2

- do not calculate the height again and again.
- reuse it by returning it while checking the balance status.

```C#
public bool IsBalanced(TreeNode root)
{
    return HeightAndBalanceStatus(root).isBalanced;
}

private (int height, bool isBalanced) HeightAndBalanceStatus(TreeNode root)
{
    if (root == null) return (0, true);

    var (leftHeight, leftBalanced) = HeightAndBalanceStatus(root.left);
    var (rightHeight, rightBalanced) = HeightAndBalanceStatus(root.right);

    var height = Math.Max(leftHeight, rightHeight) + 1;

    if(!leftBalanced || !rightBalanced) return (height, false);
    if (Math.Abs(leftHeight - rightHeight) > 1) return (height, false);

    return (height, true);
}
```

## Complexities

- **Time Complexity**: O(n) (linear time, as each node is visited only once)
- **Space Complexity**: O(n) (due to the recursion stack in the worst case)

# 215. [Kth Largest Element in an Array](https://leetcode.com/problems/kth-largest-element-in-an-array)

## Intuition

The idea is to find the Kth largest element without fully sorting the array. Using a priority queue (min-heap or max-heap) allows us to efficiently track the largest elements in the array without needing to sort everything.

## Approach

1. Use a **priority queue** to simulate a max-heap by negating the values. This ensures that the largest values in the array are dequeued first.
2. Iterate through the array, inserting each element into the priority queue.
3. After inserting all the elements, remove the largest `k-1` elements. The next element dequeued will be the Kth largest.
4. Return the Kth largest element, which is the result of the final dequeue.

## Code

```csharp
public class Solution {
    public int FindKthLargest(int[] nums, int k)
    {
        // Create a priority queue to track the largest elements
        PriorityQueue<int, int> priorityQueue = new();

        // Insert all elements into the priority queue
        for (int i = 0; i < nums.Length; i++)
            priorityQueue.Enqueue(nums[i], -nums[i]); // for descending sort

        // Remove the largest k-1 elements
        for (int i = 0; i < k - 1; i++)
            priorityQueue.Dequeue();

        // Return the kth largest element
        return priorityQueue.Dequeue();
    }
}
```

## Complexity

- **Time complexity**:
    The time complexity is $O(n \log n)$, where $n$ is the number of elements in the array. This is because we enqueue all `n` elements, each with a log time complexity due to the heap operations. Additionally, we perform `k` dequeue operations, each of which takes $O(\log n)$, but the dominant factor is still $O(n \log n)$ from the enqueuing.
- **Space complexity**:
    The space complexity is $O(n)$ because the priority queue stores all `n` elements of the array.
