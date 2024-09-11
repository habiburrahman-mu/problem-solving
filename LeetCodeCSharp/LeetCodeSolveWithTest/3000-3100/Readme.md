# 3005. [Count Elements With Maximum Frequency](https://leetcode.com/problems/kth-largest-element-in-a-stream)

## Intuition

The problem is asking for the total frequencies of all elements in the array that have the **maximum frequency**. My first thought is to count the occurrences of each element using a dictionary. Then, I can find the maximum frequency and sum up the frequencies of all elements that occur that many times.

## Approach

1. Use a Hashmap to track the frequency of each element in the array.
2. Find the maximum frequency in the map.
3. Sum the total frequency of all elements with this maximum frequency.
4. Return the final sum.

## Code

```csharp
public class Solution {
    public int MaxFrequencyElements(int[] nums)
    {
        // Create a dictionary to track the frequency of each number
        Dictionary<int, int> map = new();
        
        // Count the frequency of each number
        foreach (int num in nums)
        {
            if (map.ContainsKey(num)) 
                map[num]++;
            else 
                map[num] = 1;
        }

        // Get the maximum frequency value from the dictionary
        int max = map.Values.Max();

        // Sum the frequencies of all elements with the maximum frequency
        return map.Values.Where(x => x == max).Sum();
    }
}
```

## Complexity

- **Time complexity**:  
  - Counting the frequency of each element takes $O(n)$, where $n$ is the number of elements in the array.
  - Finding the maximum frequency takes $O(n)$.
  - Summing the frequencies of elements with the maximum frequency also takes $O(n)$.
  - Therefore, the overall time complexity is $O(n)$.

- **Space complexity**:  
  - The space complexity is $O(n)$, as we need to store the frequency of each element in the dictionary.