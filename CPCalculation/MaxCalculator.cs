using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class MaxCalculator : ICostPriceCalculator
    {

        public SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesBeforeDate = 0;
            var sharesBeforeDatePriceMax = 0.0;

            var i = 0;
            while (i < shares.Count && shares[i].PurchaseDate <= sellDate)
            {
                sharesBeforeDate += shares[i].Shares;
                sharesBeforeDatePriceMax = Math.Max(sharesBeforeDatePriceMax, shares[i].Price);

                i++;
            }

            if (sharesBeforeDate < sharesSold)
            {
                throw new InvalidOperationException("Not enough shares to sell by the specified date");
            }

            var sharesAfterDate = 0;
            var sharesAfterDatePriceMax = 0.0;

            while (i < shares.Count)
            {
                sharesAfterDate += shares[i].Shares;
                sharesAfterDatePriceMax = Math.Max(sharesAfterDatePriceMax, shares[i].Price);

                i++;
            }

            var sellingSharesTotal = sharesBeforeDatePriceMax * sharesSold;
            var remainingShares = 0;
            var remainingSharesTotal = 0.0;
            var remainingSharesPrice = Math.Max(sharesBeforeDatePriceMax, sharesAfterDatePriceMax);

            remainingShares = sharesBeforeDate - sharesSold + sharesAfterDate;
            remainingSharesTotal = remainingShares * remainingSharesPrice;

            result.CostPriceSoldShares = sharesBeforeDatePriceMax;
            result.GainLossOnSale = sellPricePerShare * sharesSold - result.CostPriceSoldShares * sharesSold;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = remainingSharesPrice * (result.RemainingShares > 0 ? 1 : 0);
            return result;
        }
    }
}
