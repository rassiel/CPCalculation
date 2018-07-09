using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class FifoCalculator : ICostPriceCalculator
    {
        public double CostPrice { get; set; }

        public SellResults Sell(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesRemaining = 0;
            var sharesToSell = sharesSold;

            var splitShareLeft = 0;
            var splitShareLeftPrice = 0.0;

            var splitPosition = 0;
            var remainingShares = 0;
            var totalCostRemaining = 0.0;

            for (int i = 0; i < shares.Count; i++)
            {
                if (shares[i].PurchaseDate <= sellDate)
                {
                    sharesRemaining = sharesToSell - shares[i].Shares;
                    if (sharesRemaining > 0)
                    {
                        splitShareLeft += shares[i].Shares;
                        splitShareLeftPrice += shares[i].Total;
                        sharesToSell = sharesRemaining;
                        continue;
                    }
                    else
                    {
                        var toLeft = shares[i].Shares + sharesRemaining;
                        splitShareLeft += toLeft;
                        splitShareLeftPrice += toLeft * shares[i].Price;

                        remainingShares = shares[i].Shares - toLeft;
                        totalCostRemaining = remainingShares * shares[i].Price;

                        splitPosition = i;
                        break;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Not enough shares to sell by the date specified");
                }
            }

            //Calculate remaining
            for (int i = splitPosition + 1; i < shares.Count; i ++)
            {
                remainingShares += shares[i].Shares;
                totalCostRemaining += shares[i].Total;
            }

            result.CostPriceSoldShares = splitShareLeftPrice / splitShareLeft;
            result.GainLossOnSale = sellPricePerShare * splitShareLeft - splitShareLeftPrice;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = totalCostRemaining / remainingShares;
            return result;
        }
    }
}
