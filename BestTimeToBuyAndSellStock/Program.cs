using System;

namespace BestTimeToBuyAndSellStock
{
    class Program
    {
        static void Main(string[] args) {
        }

        public int MaxProfit(int[] prices) {
            int net = 0, lb = int.MaxValue;
            for (int i = 0; i < prices.Length; i++) {
                int curPrice = prices[i];
                int curProfit = curPrice - lb;
                if (curPrice < lb) {
                    lb = curPrice;
                } else if ((curProfit) > net) {
                    net = curProfit;
                }
            }

            return net;
        }
    }
}
