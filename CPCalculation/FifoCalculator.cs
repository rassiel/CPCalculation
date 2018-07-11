using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class FifoCalculator : ICostPriceCalculator
    {

        public SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesBeforeDate = 0;
            var sharesBeforeDateTotal = 0.0;

            var sharesSelling = sharesSold;

            var sharesRemainingInSplit = 0;
            var sharesRemainingInSplitTotal = 0.0;

            var i = 0;
            while (i < shares.Count && shares[i].PurchaseDate <= sellDate && sharesSelling > shares[i].Shares)
            {
                sharesBeforeDate += shares[i].Shares;
                sharesBeforeDateTotal += shares[i].Total;

                sharesSelling -= shares[i].Shares;
                i++;
            }

            if (sharesSelling <= shares[i].Shares && shares[i].PurchaseDate <= sellDate)
            {
                sharesBeforeDate += sharesSelling;
                sharesBeforeDateTotal += sharesSelling * shares[i].Price;

                sharesRemainingInSplit = shares[i].Shares - sharesSelling;
                sharesRemainingInSplitTotal = sharesRemainingInSplit * shares[i].Price;
                i++;
            }

            if (sharesBeforeDate < sharesSold)
            {
                throw new InvalidOperationException("Not enough shares to sell by the specified date");
            }

            var sharesAfterDate = 0;
            var shareAfterDateTotal = 0.0;

            while (i < shares.Count)
            {
                sharesAfterDate += shares[i].Shares;
                shareAfterDateTotal += shares[i].Total;

                i++;
            }

            var remainingShares = 0;
            var remainingSharesTotal = 0.0;

            remainingShares = sharesRemainingInSplit + sharesAfterDate;
            remainingSharesTotal = sharesRemainingInSplitTotal + shareAfterDateTotal;

            var remainingSharesPrice = remainingSharesTotal / remainingShares;

            result.CostPriceSoldShares = sharesBeforeDateTotal / sharesBeforeDate;
            result.GainLossOnSale = sellPricePerShare * sharesSold - result.CostPriceSoldShares * sharesSold;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = remainingSharesPrice * (result.RemainingShares > 0 ? 1 : 0);
            return result;
        }
    }
}
