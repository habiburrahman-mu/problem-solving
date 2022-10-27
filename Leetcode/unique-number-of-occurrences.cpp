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

// Time Complexity: O(n), where n is the size of input.
// Additional Space: O(m), where m is the number of unique elements.

class Solution
{
public:
    bool uniqueOccurrences(vector<int> &arr)
    {
        unordered_map<int, int> hMap;
        for (int val : arr)
        {
            hMap[val]++;
        }

        unordered_set<int> uniqueOccurrences;

        for (pair<int, int> it : hMap)
        {
            if (!uniqueOccurrences.insert(it.second).second)
            {
                return false;
            }
        }

        return true;
    }
};

int main()
{
    Solution sol;
    vector<int> n{1, 2};
    cout << sol.uniqueOccurrences(n) << endl;
}