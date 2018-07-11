using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class SharesInventory
    {
        public IList<Share> Shares = new List<Share>();
        public int CountShares { get; protected set; } = 0;
        public double TotalInventory { get; protected set; } = 0;

        /// <summary>
        /// Adds a Share to the list of shares
        /// </summary>
        /// <param name="share"></param>
        public void Purchase(Share share)
        {
            Shares.Add(share);
            CountShares = CountShares + share.Shares;
            TotalInventory = TotalInventory + share.Total;
        }

        /// <summary>
        /// Sells the amount of shares specified by <paramref name="sharesSold"/>
        /// </summary>
        /// <param name="sharesSold">amount of shares sold</param>
        /// <param name="sellPricePerShare">sell price per share</param>
        /// <param name="sellDate">sell date</param>
        /// <param name="costPriceCalculator">cost price calculator. Assumes the list of Shares is already sorted</param>
        /// <param name="sortShares">forces the list of shares to be sorted before applying the calculation</param>
        /// <returns>A structure with after sell information</returns>
        public SellResults Sell(int sharesSold, double sellPricePerShare, DateTime sellDate, ICostPriceCalculator costPriceCalculator, bool sortShares = false)
        {
            if (sharesSold <= 0)
            {
                throw new InvalidOperationException("Shares sold must be greater than zero");
            }

            if (sharesSold > CountShares)
            {
                throw new InvalidOperationException("Can't sell more than the total of shares");
            }

            if (costPriceCalculator == null)
            {
                throw new ArgumentNullException("costPriceCalculator can't be null");
            }
            if (sortShares)
            {
                Shares.OrderBy(s => s.PurchaseDate);
            }

            var result = costPriceCalculator.Calculate(Shares, sharesSold, sellPricePerShare, sellDate);
            return result;
        }
    }
}
