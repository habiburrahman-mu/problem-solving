using LeetCodeSolveWithTest._1_100;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolveWithTest._101_200
{
    public class _121_BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            throw new NotImplementedException();
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
