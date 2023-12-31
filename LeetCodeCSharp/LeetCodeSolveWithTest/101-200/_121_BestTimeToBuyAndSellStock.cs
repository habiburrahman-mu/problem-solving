namespace LeetCodeSolveWithTest._101_200
{
    public class _121_BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            List<int> profit = new List<int>();
            for (int i = 0; i < prices.Length - 1; i++) // buy
            {
                for (int j = i + 1; j < prices.Length; j++) // sell
                {
                    profit.Add(prices[j] - prices[i]);
                }
            }

            int max = profit.Count > 0 ? profit.Max() : 0;

            return max > 0 ? max : 0;
        }

        [Theory]
        [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
        [InlineData(new int[] {  }, 0)]
        public void _121_BestTimeToBuyAndSellStock_Test(int[] prices, int expected)
        {
            // Arrange
            var sut = MaxProfit;

            // Act
            var result = sut(prices);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
