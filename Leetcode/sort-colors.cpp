#include <vector>
#include <iostream>

using namespace std;

class Solution
{
public:
    void sortColors(vector<int> &nums)
    {
        vector<int> count{0, 0, 0};
        for (int value : nums)
        {
            count[value]++;
        }

        int index = 0;
        for (int i = 0; i < count.size(); i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                nums[index++] = i;
            }
        }
    }
};

int main()
{
    Solution sol;
    vector<int> n{2, 0, 2, 1, 1, 0};
    sol.sortColors(n);
    for (int val : n)
    {
        cout << val << " ";
    }
    // cout << sol.findDuplicates(n) << endl;
}