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
    // int bitwiseComplement(int n)
    // {
    //     int i = 0;
    //     int compDec = 0;
    //     do
    //     {
    //         int bit = n & 1;
    //         if (!bit)
    //         {
    //             compDec += pow(2, i);
    //         }
    //         i++;
    //         n = n >> 1;
    //     } while (n != 0);

    //     return compDec;
    // }
    int bitwiseComplement(int n)
    {
        // let n = 5 -> 101;
        int m = n, mask = 0;
        if (m == 0)
        {
            return 1;
        }

        while (m != 0)
        {
            mask = (mask << 1) | 1;
            m = m >> 1;
        }

        // mask would be 111

        return ~n & mask; 
        // 111111.....010 & 000000....111 = 00000....010
    }
};

int main()
{
    Solution sol;
    int n = 0;
    cout << sol.bitwiseComplement(n) << endl; // 4
}