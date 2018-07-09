using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class SharesInventory
    {
        public List<Share> Shares = new List<Share>();
        public int CountShares { get; protected set; } = 0;
        public double TotalInventory { get; protected set; } = 0;

        public SharesInventory()
        {

        }

        public void Purchase(Share share)
        {
            Shares.Add(share);
            CountShares = CountShares + share.Shares;
            TotalInventory = TotalInventory + share.Total;
        }

        public SellResults Sell(int sharesSold, double sellPricePerShare, DateTime sellDate, ICostPriceCalculator costPriceCalculator)
        {
            if (sharesSold > CountShares)
            {
                throw new InvalidOperationException("Can't sell more than the total of shares");
            }
            var result = costPriceCalculator.Sell(Shares, sharesSold, sellPricePerShare, sellDate);
            return result;
        }
    }
}
