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
    int bitwiseComplement(int n)
    {
        int i = 0;
        int compDec = 0;
        do
        {
            int bit = n & 1;
            if (!bit)
            {
                compDec += pow(2, i);
            }
            i++;
            n = n >> 1;
        } while (n != 0);

        return compDec;
    }
};

int main()
{
    Solution sol;
    int n = 0;
    cout << sol.bitwiseComplement(n) << endl; // 4
}