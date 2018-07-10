﻿using System;
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
            Assert.AreEqual(result.CostPriceSoldShares, 10.666, 0.001);
            Assert.AreEqual(result.GainLossOnSale, -20);
            Assert.AreEqual(result.RemainingShares, 70);
            Assert.AreEqual(result.CostPriceRemaining, 10.7142, 0.001);
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
