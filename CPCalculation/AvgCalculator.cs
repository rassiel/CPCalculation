using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class AvgCalculator : ICostPriceCalculator
    {

        public SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesBeforeDate = 0;
            var sharesBeforeDateTotalPrices = 0.0;
            var sharesBeforeDatePricesCount = 0;

            var sharesSelling = sharesSold;

            var sharesRemainingInSplit = 0;
            var sharesRemainingInSplitPrice = 0.0;

            var i = 0;
            var remainingPricesCount = 0;
            while (i < shares.Count && shares[i].PurchaseDate <= sellDate && sharesSelling > shares[i].Shares)
            {
                sharesBeforeDate += shares[i].Shares;
                sharesBeforeDateTotalPrices += shares[i].Price;
                sharesBeforeDatePricesCount++;

                sharesSelling -= shares[i].Shares;
                i++;
            }

            if (sharesSelling <= shares[i].Shares && shares[i].PurchaseDate <= sellDate)
            {
                sharesBeforeDate += sharesSelling;
                sharesBeforeDateTotalPrices += shares[i].Price;
                sharesBeforeDatePricesCount++;

                sharesRemainingInSplit = shares[i].Shares - sharesSelling;
                sharesRemainingInSplitPrice = shares[i].Price;
                remainingPricesCount++;
                i++;
            }

            if (sharesBeforeDate < sharesSold)
            {
                throw new InvalidOperationException("Not enough shares to sell by the specified date");
            }

            var sharesAfterDate = 0;
            var shareAfterDateTotalPrices = 0.0;

            while (i < shares.Count)
            {
                sharesAfterDate += shares[i].Shares;
                shareAfterDateTotalPrices += shares[i].Price;

                remainingPricesCount++;
                i++;
            }

            var remainingShares = 0;
            var remainingSharesTotalPrices = 0.0;

            remainingShares = sharesRemainingInSplit + sharesAfterDate;
            remainingSharesTotalPrices = sharesRemainingInSplitPrice + shareAfterDateTotalPrices;

            var remainingSharesAvg = remainingSharesTotalPrices / remainingPricesCount;

            result.CostPriceSoldShares = sharesBeforeDateTotalPrices / sharesBeforeDatePricesCount;
            result.GainLossOnSale = sellPricePerShare * sharesSold - result.CostPriceSoldShares * sharesSold;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = remainingSharesAvg * (result.RemainingShares > 0 ? 1 : 0);
            return result;
        }
    }
}
