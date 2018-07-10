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

            //var sharesBeforeDate = 0;
            //var sharesBeforeDatePriceAvg = 0.0;
            //var sharesBeforeDateTotal = 0.0;

            //var sharesSelling = sharesSold;
            //var sharesSellingTotal = 0.0;

            //var i = 0;
            //while (shares[i].PurchaseDate <= sellDate && sharesSelling > shares[i].Shares && i < shares.Count)
            //{
            //    sharesBeforeDate += shares[i].Shares;
            //    sharesBeforeDateTotal += shares[i].Total;

            //    sharesSelling -= shares[i].Shares;
            //    i++;
            //}

            //if (sharesSelling <= shares[i].Shares)
            //{
            //    sharesSelling = shares[i].Shares - sharesSelling;
            //    sharesRemainingInSplitTotal = shares[i].Price;
            //}


            //sharesBeforeDatePriceAvg = sharesBeforeDateTotal / sharesBeforeDate;

            //if (sharesBeforeDate < sharesSold)
            //{
            //    throw new InvalidOperationException("Not enough shares to sell by the specified date");
            //}

            //var sharesAfterDate = 0;
            //var shareAfterDateTotal = 0.0;

            //while (i < shares.Count)
            //{
            //    sharesAfterDate += shares[i].Shares;
            //    shareAfterDateTotal += shares[i].Total;

            //    i++;
            //}
            
            //sharesBeforeDatePriceAvg = shareAfterDateTotal / sharesAfterDate;


            //var remainingShares = 0;
            //var remainingSharesTotal = 0.0;
            //var remainingSharesAvg = 0.0;

            //remainingShares = sharesBeforeDate - sharesSold + sharesAfterDate;
            //remainingSharesTotal = remainingShares * remainingSharesPrice;

            //result.CostPriceSoldShares = sharesBeforeDatePriceMin;
            //result.GainLossOnSale = sellPricePerShare * sharesSold - sellingSharesTotal;
            //result.RemainingShares = remainingShares;
            //result.CostPriceRemaining = remainingSharesPrice;
            return result;
        }
    }
}
