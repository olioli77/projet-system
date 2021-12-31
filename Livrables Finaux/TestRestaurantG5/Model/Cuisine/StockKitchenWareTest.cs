using System;
using RestaurantG5.Model.Cuisine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRestaurantG5.Model.Cuisine
{
    [TestClass]
    public class StockKitchenWareTest
    {
        [TestMethod]
        public void TestStockKitchenwareInstance()
        {
            StockKitchenWare test = StockKitchenWare.Instance;
            Assert.IsNotNull(StockKitchenWare.Instance);
            Assert.AreEqual(test, StockKitchenWare.Instance);
        }

        [TestMethod]
        public void TestStockKitchenwareConstructValues()
        {
            StockKitchenWare test = StockKitchenWare.Instance;
            Assert.IsNotNull(test.Stock);
        }
    }
}
