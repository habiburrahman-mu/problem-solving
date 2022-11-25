#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <algorithm>
#include <cmath>
#include <map>
#include <unordered_map>
#include <unordered_set>

using namespace std;

class Solution
{
public:
    vector<int> searchRange(vector<int> &nums, int target)
    {
        vector<int> ans{-1, -1};

        int start = 0, end = nums.size() - 1;
        int mid;

        while (start <= end)
        {
            mid = start + ((end - start) / 2);

            if (nums[mid] == target)
            {
                ans[1] = mid;
                start = mid + 1;
            }
            else if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        start = 0, end = ans[1];

        while (start <= end)
        {
            mid = start + ((end - start) / 2);

            if (nums[mid] == target)
            {
                ans[0] = mid;
                end = mid - 1;
            }
            else if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        return ans;
    }
};

int main()
{
    Solution sol;
    vector<int> nums{5, 7, 7, 8, 8, 8, 10};
    int target = 8;
    for (int val : sol.searchRange(nums, target))
    {
        cout << val << " ";
    }
}