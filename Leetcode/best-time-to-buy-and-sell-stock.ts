
function maxProfitBruteForceWithTLE(prices: number[]): number {
    let maxProfit = 0;
    for (let i = 0; i < prices.length - 1; i++) {
        let maxProfitForThis = 0;
        let maxSell = Math.max(...prices.slice(i + 1, prices.length));
        if (maxSell > prices[i]) {
            maxProfitForThis = maxSell - prices[i];
        } else {
            maxProfitForThis = 0;
        }
        if(maxProfitForThis > maxProfit){
            maxProfit = maxProfitForThis;
        }
    }
    if(maxProfit > 0){
        return maxProfit;
    }
    return 0;
};

// let prices = [7,6,4,3,1];
// console.log(maxProfit(prices));