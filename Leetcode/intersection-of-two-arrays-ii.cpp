#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

class Solution
{
public:
    vector<int> intersect(vector<int> &nums1, vector<int> &nums2)
    {
        vector<int> result;

        unordered_map<int, int> mp1;

        for (int val : nums1)
        {
            mp1[val]++;
        }

        for (int val : nums2)
        {
            if (mp1[val])
            {
                result.push_back(val);
                mp1[val]--;
            }
        }

        return result;
    }
};

int main()
{
    Solution sol;
    vector<int> n{4, 9, 5};
    vector<int> m{9, 4, 9, 8, 4};
    for (int val : sol.intersect(n, m))
    {
        cout << val << " ";
    }
    // cout << sol.findDuplicates(n) << endl;
}