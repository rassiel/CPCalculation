using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public class Share
    {
        public DateTime PurchaseDate { get; set; }
        public int Shares { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

        /// <summary>
        /// Constructs a Share
        /// </summary>
        /// <param name="purchaseDate">date of purchase</param>
        /// <param name="shares">amount of shares</param>
        /// <param name="price">total purchase price</param>
        public Share(DateTime purchaseDate, int shares, double price)
        {
            if (shares <= 0)
                throw new InvalidOperationException("Amount of shares must be greater than zero");
            if (price <= 0)
                throw new InvalidOperationException("price must be greater than zero");

            PurchaseDate = purchaseDate;
            Shares = shares;
            Price = price;
            Total = Price * shares;
        }
    }
}
