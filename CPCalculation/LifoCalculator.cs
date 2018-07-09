using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class LifoCalculator : ICostPriceCalculator
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

            for (int i = shares.Count - 1; i >= 0 ; i--)
            {
                if (shares[i].PurchaseDate > sellDate)
                {
                    sharesRemaining += shares[i].Shares;
                    totalCostRemaining += shares[i].Total;
                }
                else
                {

                }
            }


            result.CostPriceSoldShares = splitShareLeftPrice / splitShareLeft;
            result.GainLossOnSale = sellPricePerShare * splitShareLeft - splitShareLeftPrice;
            result.RemainingShares = remainingShares;
            result.CostPriceRemaining = totalCostRemaining / remainingShares;
            return result;
        }
    }
}
