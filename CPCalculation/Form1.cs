using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPCalculation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var sharesSold = 0;
            var pricePerShare = 0.0;
            var sellDate = DateTime.Today;

            List<Share> SharesSample = new List<Share>()
                {
                    new Share(
                        new DateTime(2005, 1, 1),
                        100,
                        10
                    ),
                    new Share(
                        new DateTime(2005, 2, 2),
                        40,
                        12
                    ),
                    new Share(
                        new DateTime(2005, 3, 3),
                        50,
                        11
                    )
                };

            var shares = new SharesInventory();
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);

            SellResults results;

            int.TryParse(txtSharesSold.Text, out sharesSold);
            if (sharesSold <= 0)
            {
                displayMessage("shares sold invalid");
                return;
            }

            double.TryParse(txtPricePerShare.Text, out pricePerShare);
            if (pricePerShare <= 0)
            {
                displayMessage("price per shares invalid");
                return;
            }

            if (!DateTime.TryParse(txtSellDate.Text, out sellDate))
            {
                displayMessage("invalid date");
                return;
            }

            ICostPriceCalculator costPriceCalculator;
            switch (cbMethod.Text)
            {
                case "Lifo":
                    costPriceCalculator = new LifoCalculator();
                    break;
                case "Fifo":
                    costPriceCalculator = new FifoCalculator();
                    break;
                case "Max":
                    costPriceCalculator = new MaxCalculator();
                    break;
                case "Min":
                    costPriceCalculator = new MinCalculator();
                    break;
                case "Avg":
                    costPriceCalculator = new AvgCalculator();
                    break;
                default:
                    displayMessage("must select a valid method");
                    return;
            }

            try
            {
                results = shares.Sell(sharesSold, pricePerShare, sellDate, costPriceCalculator);
            }
            catch (InvalidOperationException ex)
            {
                displayMessage(ex.Message);
                return;
            }
            lblResults.Text = string.Format("Cost Price of Sold Shares: {0}\nGain Loss On Sale: {1}\n" + 
                "Number of Remaining Shares: {2}\n" + 
                "Cost Price of Remaining Shares: {3}", results.CostPriceSoldShares, results.GainLossOnSale, results.RemainingShares, results.CostPriceRemaining);

        }

        public void displayMessage(string message)
        {
            lblResults.Text = message;
        }
    }
}
