#include <vector>
#include <iostream>

using namespace std;

class Solution
{
public:
    void sortColors(vector<int> &nums)
    {
        int low = 0, mid = 0, high = nums.size() - 1;

        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                swap(nums[low], nums[mid]);
                low++;
                mid++;
            }
            else if (nums[mid] == 1)
            {
                mid++;
            }
            else if (nums[mid] == 2)
            {
                swap(nums[mid], nums[high]);
                high--;
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
}