
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

function maxProfitOneIteration(prices: number[]): number {
    let minimumPrice = Number.MAX_SAFE_INTEGER;
    let maximumProfit = 0;
    for (let i = 0; i < prices.length; i++) {
        if (prices[i] < minimumPrice) {
            minimumPrice = prices[i];
        }
        let profit = prices[i] - minimumPrice;
        if (profit > maximumProfit) {
            maximumProfit = profit;
        };
    }
    return maximumProfit;
};

function maxProfit(prices: number[]): number {
    if (prices.length === 0)
        return 0;

    let currentMin = prices[0];
    let maxProfit = 0;

    for (let i = 1; i < prices.length; i++) {
        currentMin = prices[i] < currentMin ? prices[i] : currentMin;
        maxProfit = prices[i] - currentMin > maxProfit ? prices[i] - currentMin : maxProfit;
    }
    
    return maxProfit;
};

// let prices = [7,6,4,3,1];
// console.log(maxProfit(prices));