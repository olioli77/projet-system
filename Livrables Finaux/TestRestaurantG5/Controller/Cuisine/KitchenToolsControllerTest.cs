using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRestaurantG5.Controller.Cuisine
{
    [TestClass]
    public class KitchenToolsControllerTest
    {
        [TestMethod]
        public void SendDirtyToolsTest()
        {


        }

        [TestMethod]
        public void SetInUseToolTest()
        {
            //Impossible to test a Semaphore
        }

        [TestMethod]
        public void ReceiveCleanToolsTest()
        {
            //stockkitchenware.instance.clean["spoon"] = 5;
            //stockkitchenware.instance.dirty["spoon"] = 0;

            //kitchentoolscontroller cleaner = new kitchentoolscontroller();

            //cleaner.senddirtytools("spoon", 3);
            //cleaner.receivecleantools("spoon", 2);

            //assert.areequal(stockkitchenware.instance.clean["spoon"], 4);
            //assert.areequal(stockkitchenware.instance.dirty["spoon"], 1);
        }

        [TestMethod]
        public void VerifyStockTest()
        {
            //StockKitchenware.Instance.Clean["spoon"] = 5;
            //StockKitchenware.Instance.Dirty["spoon"] = 0;

            //KitchenToolsController cleaner = new KitchenToolsController();
            //Assert.AreEqual(cleaner.VerifyStock("spoon", 3), true);
            //Assert.AreEqual(cleaner.VerifyStock("spoon", 0), false);
            //Assert.AreEqual(cleaner.VerifyStock("spoon", -2), false);
            //Assert.AreEqual(cleaner.VerifyStock("spoon", 10), false);

        }
    }
}
