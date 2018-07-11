using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPCalculation;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class LifoCalculatorTests
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
        public void LifoCalculator_Sample()
        {
            //Arrange
            var shares = new SharesInventory();
            var lifoCalculator = new LifoCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 3, 2), lifoCalculator);

            //Assert
            Assert.AreEqual(10.666, result.CostPriceSoldShares,0.001);
            Assert.AreEqual(-20, result.GainLossOnSale);
            Assert.AreEqual(70, result.RemainingShares);
            Assert.AreEqual(10.7142, result.CostPriceRemaining, 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LifoCalculator_NotEnoughSharesByDate()
        {
            //Arrange
            var shares = new SharesInventory();
            var lifoCalculator = new LifoCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 1, 1), lifoCalculator);

            //Assert
        }

    }
}
