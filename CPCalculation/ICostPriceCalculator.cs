using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public interface ICostPriceCalculator
    {
        double CostPrice { get; set; }
        SellResults Sell(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate);
    }
}
