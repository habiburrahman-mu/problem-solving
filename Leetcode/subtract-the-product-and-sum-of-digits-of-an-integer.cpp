#include <iostream>
#include <string>
#include <utility>
#include <vector>
#include <algorithm>

using namespace std;

class Solution
{
public:
    int subtractProductAndSum(int n)
    {
        int sum = 0, product = 1, rem = 1, number = n;
        while (number != 0)
        {
            rem = number % 10;
            sum += rem;
            product *= rem;
            number = number / 10;
        }

        return product - sum;
    }
};

int main()
{
    Solution sol;
    int n = 114;
    cout << sol.subtractProductAndSum(n) << endl;
}