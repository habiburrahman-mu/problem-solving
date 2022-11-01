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

using namespace std;

class Solution
{
public:
    vector<int> intersection(vector<int> &nums1, vector<int> &nums2)
    {
        unordered_map<int, int> mp1;
        unordered_map<int, int> mp2;

        set<int> st;

        vector<int> result;

        for (int val : nums1) // O(N)
        {
            mp1[val]++; // O(1)
        }

        for (int val : nums2) // O(NlogN)
        {
            if (mp1[val] > 0) // O(1)
            {
                st.insert(val); // O(logN)
            }
        }

        for (int val : st)
        { // O(N)
            result.push_back(val);
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