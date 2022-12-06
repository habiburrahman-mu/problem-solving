#include <vector>
#include <iostream>

using namespace std;

class Solution
{
public:
    int peakIndexInMountainArray(vector<int> &arr)
    {
        int start = 0, end = arr.size() - 1;

        while (start < end)
        {
            int mid = start + (end - start) / 2;
            if (arr[mid] < arr[mid + 1])
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }
        }

        return start;
    }
};

int main()
{
    Solution sol;
    vector<int> n{0, 10, 3, 0};
    cout << sol.peakIndexInMountainArray(n) << endl; // 1
}