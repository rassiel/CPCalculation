using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public interface ICostPriceCalculator
    {
        SellResults Calculate(IList<Share> shares, int sharesSold, double sellPricePerShare, DateTime sellDate);
    }
}
