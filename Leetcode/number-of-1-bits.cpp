#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <algorithm>

using namespace std;

class Solution
{
public:
    int hammingWeight(uint32_t n)
    {
        int ct = 0;
        while (n != 0)
        {
            if (n & 1)
            {
                ct++;
            }
            n = n >> 1;
        }
        return ct;
    }
};

int main()
{
    Solution sol;
    uint32_t n = 0000001100011;
    cout << sol.hammingWeight(n) << endl; // 4
}