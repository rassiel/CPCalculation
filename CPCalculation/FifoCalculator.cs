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

            var sharesRemaining = 0;
            var sharesToSell = sharesSold;

            var sellingShares = 0;
            var sellingSharesTotal = 0.0;

            var splitPosition = 0;
            var remainingShares = 0;
            var remainingSharesTotal = 0.0;

            for (int i = 0; i < shares.Count; i++)
            {
                if (shares[i].PurchaseDate <= sellDate)
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

                        remainingShares = shares[i].Shares - finalFillingShares;
                        remainingSharesTotal = remainingShares * shares[i].Price;

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
                remainingSharesTotal += shares[i].Total;
            }

            result.CostPriceSoldShares = sellingSharesTotal / sellingShares;
            result.GainLossOnSale = sellPricePerShare * sellingShares - sellingSharesTotal;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = remainingSharesTotal / remainingShares;
            return result;
        }
    }
}
