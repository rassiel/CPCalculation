using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPCalculation;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class FifoCalculatorTests
    {
        public List<Share> SharesSample = new List<Share>()
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

        [TestMethod]
        public void FifoCalculator_Sample()
        {
            //Arrange
            var shares = new SharesInventory();
            var fifoCalculator = new FifoCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 3, 2), fifoCalculator);

            //Assert
            Assert.AreEqual(result.CostPriceSoldShares, 10.333, 0.001);
            Assert.AreEqual(result.GainLossOnSale, 20);
            Assert.AreEqual(result.RemainingShares, 70);
            Assert.AreEqual(result.CostPriceRemaining, 11.2857, 0.001);

        }
    }
}
