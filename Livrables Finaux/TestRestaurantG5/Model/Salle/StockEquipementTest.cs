using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Components;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class StockEquipementTest
    {
        [TestMethod]
        public void TestStockEquipmentInstance()
        {
            StockEquipement test = StockEquipement.Instance;
            Assert.IsNotNull(StockEquipement.Instance);
            Assert.AreEqual(test, StockEquipement.Instance);
        }
        [TestMethod]
        public void TestStockEquipmentConstructValues()
        {
            StockEquipement test = StockEquipement.Instance;
            Assert.IsNotNull(test.Clean);
            Assert.IsNotNull(test.Dirty);
        }
    }
}
