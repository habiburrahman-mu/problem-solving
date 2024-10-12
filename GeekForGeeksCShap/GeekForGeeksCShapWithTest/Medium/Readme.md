# Medium Problems of GeekForGeeks

## [Rat in a Maze Problem - I](https://www.geeksforgeeks.org/problems/rat-in-a-maze-problem/1)

### Intuition

The "Rat in a Maze Problem" involves navigating from the top-left corner of a matrix (0,0) to the bottom-right corner (n-1,n-1). The matrix consists of open paths (1s) and blocked paths (0s). The challenge is to find all possible paths the rat can take to reach its destination, moving in four possible directions: Down (D), Left (L), Right (R), and Up (U). The solution must avoid revisiting cells and blocked paths, ensuring that the rat only moves through valid cells.

### Approaches

[**Video Explanation**](https://www.youtube.com/watch?v=wjqSZy4pMT4&list=PLDzeHZWIZsTryvtXdMr6rPh4IDexB5NIA&index=92)

#### Approach 1: Depth-First Search (DFS)

The problem can be tackled using Depth-First Search (DFS) with backtracking. The idea is to start from the top-left corner, and for each valid move, explore deeper into the maze, marking cells as visited. If the rat reaches the bottom-right corner, a valid path is found. The algorithm backtracks when it hits an invalid move or a dead-end, resetting the visited status and exploring other directions.

##### Code

```csharp
public List<string> Solution(List<List<int>> mat)
{
    var ans = new List<string>();
    var n = mat.Count;

    // Edge case: if the matrix is empty or the starting point is blocked, return empty result.
    if (n == 0 || mat[0][0] == 0)
        return ans;

    // Initialize the visited matrix with all cells unvisited (0).
    var visited = Enumerable.Range(0, n)
        .Select(_ => Enumerable.Repeat(0, mat[0].Count).ToList())
        .ToList();

    string path = string.Empty;

    // Start the DFS traversal from the top-left corner (0,0).
    Solve(0, 0, mat, n, ans, visited, path);

    return ans;
}

void Solve(int x, int y, List<List<int>> mat, int n, List<string> ans, List<List<int>> visited, string path)
{
    // If the rat has reached the bottom-right corner, add the path to the result.
    if (x == n - 1 && y == n - 1)
    {
        ans.Add(path);
        return;
    }

    // Mark the current cell as visited.
    visited[x][y] = 1;

    // Explore Down (D)
    if (IsSafe(x + 1, y, visited, mat, n))
    {
        Solve(x + 1, y, mat, n, ans, visited, path + "D");
    }

    // Explore Left (L)
    if (IsSafe(x, y - 1, visited, mat, n))
    {
        Solve(x, y - 1, mat, n, ans, visited, path + "L");
    }

    // Explore Right (R)
    if (IsSafe(x, y + 1, visited, mat, n))
    {
        Solve(x, y + 1, mat, n, ans, visited, path + "R");
    }

    // Explore Up (U)
    if (IsSafe(x - 1, y, visited, mat, n))
    {
        Solve(x - 1, y, mat, n, ans, visited, path + "U");
    }

    // Backtrack: Unmark the current cell before returning to the previous step.
    visited[x][y] = 0;
}

bool IsSafe(int newx, int newy, List<List<int>> visited, List<List<int>> mat, int n)
{
    // Ensure that the new cell is within the matrix bounds, not visited, and is not blocked.
    return newx >= 0 && newy >= 0
        && newx < n && newy < n
        && visited[newx][newy] == 0
        && mat[newx][newy] == 1;
}

```

#### Complexity Analysis

- **Time Complexity**: `O(4^(n*n))`
    - Each cell can be visited in four possible directions (Down, Left, Right, Up). In the worst case, all cells may be visited in all possible directions, leading to a time complexity of `O(4^(n*n))`, where `n` is the size of the matrix.
- **Space Complexity**: `O(n*n)`
    - The space complexity is dominated by the recursion stack in the depth-first search, which can go as deep as `n*n` in the worst case. Additionally, the `visited` matrix takes `O(n*n)` space.