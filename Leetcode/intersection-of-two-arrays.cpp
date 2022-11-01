#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <algorithm>
#include <cmath>
#include <map>
#include <unordered_map>
#include <unordered_set>
#include <set>
#include <unordered_set>

using namespace std;

class Solution
{
public:
    vector<int> intersection(vector<int> &nums1, vector<int> &nums2)
    {
        unordered_set<int> st(nums1.begin(), nums1.end());
        vector<int> result;
        for (int value : nums2)
        {
            if (st.count(value))
            {
                result.push_back(value);
                st.erase(value);
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
    for (int val : sol.intersection(n, m))
    {
        cout << val << " ";
    }
    // cout << sol.findDuplicates(n) << endl;
}