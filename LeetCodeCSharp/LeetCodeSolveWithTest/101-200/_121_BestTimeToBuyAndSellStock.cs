namespace LeetCodeSolveWithTest._101_200
{
    public class _121_BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            int cheapest = prices[0];
            int maxProfit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if(prices[i] < cheapest)
                {
                    cheapest = prices[i];
                } 
                else
                {
                    int profit = prices[i] - cheapest;
                    maxProfit = Math.Max(maxProfit, profit);
                }
            }
            return maxProfit;
        }

        [Theory]
        [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
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
