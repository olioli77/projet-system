using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Controller.Salle;
using RestaurantG5.Model.Salle.Components;

namespace TestRestaurantG5
{
    [TestClass]
    public class MaterielControllerTest
    {
        [TestMethod]
        public void TestdefineAsDirty()
        {
            /*StockEquipement.ResetInstance();
            StockEquipement.Instance.InUse["towel"] = 1;
            MaterielController.defineAsDirty("towel");

            Assert.AreEqual(1, StockEquipement.Instance.Dirty["towel"]);
            Assert.AreEqual(0, StockEquipement.Instance.InUse["towel"]);

            StockEquipement.Instance.InUse["teaspoon"] = 5;
            MaterielController.defineAsDirty("teaspoon");
            MaterielController.defineAsDirty("teaspoon");

            Assert.AreEqual(2, StockEquipement.Instance.Dirty["teaspoon"]);
            Assert.AreEqual(3, StockEquipement.Instance.InUse["teaspoon"]);*/
        }

        [TestMethod]
        public void TestdefineAsInUse()
        {
            StockEquipement.ResetInstance();
            Assert.IsTrue(MaterielController.defineAsInUse("towel"));

            Assert.AreEqual(1, StockEquipement.Instance.InUse["towel"]);
            Assert.AreEqual(149, StockEquipement.Instance.Clean["towel"]);


            MaterielController.defineAsInUse("teaspoon");
            MaterielController.defineAsInUse("teaspoon");

            Assert.AreEqual(2, StockEquipement.Instance.InUse["teaspoon"]);
            Assert.AreEqual(148, StockEquipement.Instance.Clean["teaspoon"]);
        }

        [TestMethod]
        public void TestdefineAsClean()
        {
            StockEquipement.ResetInstance();
            StockEquipement.Instance.Washing["towel"] = 1;
            Assert.IsTrue(MaterielController.defineAsClean("towel"));

            Assert.AreEqual(0, StockEquipement.Instance.Washing["towel"]);
            Assert.AreEqual(151, StockEquipement.Instance.Clean["towel"]);

            StockEquipement.Instance.Washing["teaspoon"] = 5;
            MaterielController.defineAsClean("teaspoon");
            MaterielController.defineAsClean("teaspoon");

            Assert.AreEqual(3, StockEquipement.Instance.Washing["teaspoon"]);
            Assert.AreEqual(152, StockEquipement.Instance.Clean["teaspoon"]);
        }

        [TestMethod]
        public void TestdefineAsWashing()
        {
            StockEquipement.ResetInstance();
            StockEquipement.Instance.Dirty["towel"] = 1;
            Assert.IsTrue(MaterielController.defineAsWashing("towel"));

            Assert.AreEqual(1, StockEquipement.Instance.Washing["towel"]);
            Assert.AreEqual(0, StockEquipement.Instance.Dirty["towel"]);

            StockEquipement.Instance.Dirty["teaspoon"] = 5;
            MaterielController.defineAsWashing("teaspoon");
            MaterielController.defineAsWashing("teaspoon");

            Assert.AreEqual(2, StockEquipement.Instance.Washing["teaspoon"]);
            Assert.AreEqual(3, StockEquipement.Instance.Dirty["teaspoon"]);
        }
    }
}
