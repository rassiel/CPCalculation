using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class MinCalculator : ICostPriceCalculator
    {

        public SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate)
        {
            var result = new SellResults();

            var sharesBeforeDate = 0;
            var sharesBeforeDatePriceMin = double.MaxValue;

            var i = 0;
            while (shares[i].PurchaseDate <= sellDate && i < shares.Count)
            {
                sharesBeforeDate += shares[i].Shares;
                sharesBeforeDatePriceMin = Math.Min(sharesBeforeDatePriceMin, shares[i].Price);

                i++;
            }

            if (sharesBeforeDate < sharesSold)
            {
                throw new InvalidOperationException("Not enough shares to sell by the specified date");
            }

            var sharesAfterDate = 0;
            var sharesAfterDatePriceMin = double.MaxValue;

            while (i < shares.Count)
            {
                sharesAfterDate += shares[i].Shares;
                sharesAfterDatePriceMin = Math.Min(sharesAfterDatePriceMin, shares[i].Price);

                i++;
            }

            var sellingSharesTotal = sharesBeforeDatePriceMin * sharesSold;
            var remainingShares = 0;
            var remainingSharesTotal = 0.0;
            var remainingSharesPrice = Math.Min(sharesBeforeDatePriceMin, sharesAfterDatePriceMin);

            remainingShares = sharesBeforeDate - sharesSold + sharesAfterDate;
            remainingSharesTotal = remainingShares * remainingSharesPrice;

            result.CostPriceSoldShares = sharesBeforeDatePriceMin;
            result.GainLossOnSale = sellPricePerShare * sharesSold - sellingSharesTotal;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = remainingSharesPrice;
            return result;
        }
    }
}
