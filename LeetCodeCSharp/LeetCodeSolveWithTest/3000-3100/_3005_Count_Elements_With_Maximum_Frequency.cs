namespace LeetCodeSolveWithTest._3000_3100
{
    public class _3005_Count_Elements_With_Maximum_Frequency
    {
        public int MaxFrequencyElements(int[] nums)
        {
            Dictionary<int, int> map = new();
            foreach (int num in nums)
            {
                if (map.ContainsKey(num)) 
                    map[num]++;
                else 
                    map[num] = 1;
            }

            int max = map.Values.Max();
            map.Values.Where(x => x == max).Sum();
            return map.Values.Where(x => x == max).Sum();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 2, 3, 1, 4 }, 4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
        public void _3005_Count_Elements_With_Maximum_Frequency_Test(int[] nums, int expected)
        {
            // Arrange
            var sut = MaxFrequencyElements;

            // Act
            var result = sut(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
