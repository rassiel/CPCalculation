using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCalculation
{
    public struct SellResults
    {
        public double CostPriceSoldShares { get; set; }
        public double GainLossOnSale { get; set; }
        public int RemainingShares { get; set; }
        public double CostPriceRemaining { get; set; }
    }
}
