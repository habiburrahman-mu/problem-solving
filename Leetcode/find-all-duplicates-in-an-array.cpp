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
    vector<int> findDuplicates(vector<int> &nums)
    {
        vector<int> ans;
        if (nums.size() == 0)
        {
            return {};
        }

        for (int i = 0; i < nums.size(); i++)
        {
            int index = abs(nums[i]) - 1;
            if (nums[index] > 0)
            {
                nums[index] *= -1;
            }
            else 
            {
                ans.push_back(abs(nums[i]));
            }
        }

        return ans;
    }
};

int main()
{
    Solution sol;
    vector<int> n{4,3,2,7,8,2,3,1};
    for (int val : sol.findDuplicates(n))
    {
        cout << val << " ";
    }
    // cout << sol.findDuplicates(n) << endl;
}