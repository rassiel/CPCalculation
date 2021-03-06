﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPCalculation;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class MaxCalculatorTests
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
        public void MaxCalculator_Sample()
        {
            //Arrange
            var shares = new SharesInventory();
            var MaxCalculator = new MaxCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 3, 2), MaxCalculator);

            //Assert
            Assert.AreEqual(12, result.CostPriceSoldShares,0.001);
            Assert.AreEqual(-180, result.GainLossOnSale);
            Assert.AreEqual(70, result.RemainingShares);
            Assert.AreEqual(12, result.CostPriceRemaining, 0.001);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaxCalculator_NotEnoughSharesByDate()
        {
            //Arrange
            var shares = new SharesInventory();
            var maxCalculator = new MaxCalculator();

            //Act
            shares.Purchase(SharesSample[0]);
            shares.Purchase(SharesSample[1]);
            shares.Purchase(SharesSample[2]);
            var result = shares.Sell(120, 10.5, new DateTime(2005, 1, 1), maxCalculator);

            //Assert
        }
    }
}
