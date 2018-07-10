using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class LifoCalculator : ICostPriceCalculator
    {
        public SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesRemaining = 0;
            var sharesToSell = sharesSold;

            var sellingShares = 0;
            var sellingSharesTotal = 0.0;

            var splitPosition = 0;
            var remainingSharesAfter = 0; //shares after date
            var remainingSharesAfterTotal = 0.0;

            var remainingSharesBefore = 0; //shares before split position
            var remainingSharesBeforeTotal = 0.0;

            var remainingSharesInSplit = 0; //shares remaining in the split position
            var remaininSharesInSplitTotal = 0.0;

            for (int i = shares.Count - 1; i >= 0 ; i--)
            {

                if (shares[i].PurchaseDate > sellDate)
                {
                    remainingSharesAfter += shares[i].Shares;
                    remainingSharesAfterTotal += shares[i].Total;
                }
                else
                {
                    sharesRemaining = sharesToSell - shares[i].Shares;
                    if (sharesRemaining > 0)
                    {
                        sellingShares += shares[i].Shares;
                        sellingSharesTotal += shares[i].Total;
                        sharesToSell = sharesRemaining;
                        continue;
                    }
                    else 
                    {
                        var finalFillingShares = shares[i].Shares + sharesRemaining;
                        sellingShares += finalFillingShares;
                        sellingSharesTotal += finalFillingShares * shares[i].Price;

                        remainingSharesInSplit = shares[i].Shares - finalFillingShares;
                        remaininSharesInSplitTotal = remainingSharesInSplit * shares[i].Price;

                        splitPosition = i;
                        break;
                    }
                }
            }

            if (sellingShares !=  sharesSold)
            {
                throw new InvalidOperationException("Not enough shares to sell by the specified date");
            }

            //Calculate remaining positions before split
            for (int i = splitPosition - 1; i >= 0; i--)
            {
                remainingSharesBefore += shares[i].Shares;
                remainingSharesBeforeTotal += shares[i].Total;
            }
            //Combine
            var totalRemainingShares = remainingSharesBefore + remainingSharesInSplit + remainingSharesAfter;
            var totalRemainingSharesTotal = remainingSharesBeforeTotal + remaininSharesInSplitTotal + remainingSharesAfterTotal;


            result.CostPriceSoldShares = sellingSharesTotal / sellingShares;
            result.GainLossOnSale = sellPricePerShare * sellingShares - sellingSharesTotal;
            result.RemainingShares = totalRemainingShares;
            result.CostPriceRemaining = totalRemainingSharesTotal / totalRemainingShares;
            return result;
        }
    }
}
