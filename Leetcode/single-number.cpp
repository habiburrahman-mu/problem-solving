#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;

class Solution
{
public:
    int singleNumber(vector<int> &nums)
    {
        int ans = 0;
        for(int value: nums) {
            ans ^= value;
        }
        return ans;
    }
};

int main()
{
    Solution sol;
    vector<int> n {1,1,2,3,2,4,4};
    cout << sol.singleNumber(n) << endl;
}