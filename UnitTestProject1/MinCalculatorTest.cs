using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPCalculation;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class MinCalculatorTests
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
        public void MinCalculator_Sample()
        {
            //Arrange
            var shares = new SharesInventory();
            var MinCalculator = new MinCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 3, 2), MinCalculator);

            //Assert
            Assert.AreEqual(10, result.CostPriceSoldShares, 0.001);
            Assert.AreEqual(60, result.GainLossOnSale);
            Assert.AreEqual(70, result.RemainingShares);
            Assert.AreEqual(10, result.CostPriceRemaining, 0.001);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinCalculator_NotEnoughSharesByDate()
        {
            //Arrange
            var shares = new SharesInventory();
            var MinCalculator = new MinCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 1, 1), MinCalculator);

            //Assert
        }
    }
}
