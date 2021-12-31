using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Controller;
using RestaurantG5.Controller.Cuisine;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Cuisine;
using RestaurantG5.Model.Salle.Components;
using System.Linq;

namespace TestRestaurantG5
{
    [TestClass]
    public class KitchenReceipeControllerTest
    {
        [TestMethod]
        public void CookCallbackTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
        [TestMethod]
        public void GetReceipeTest()
        {
          /*  int couteauCleanQuantityBefore = StockEquipement.Instance.Clean["couteau"];
            Recette receipe = BDDController.Instance.DB.Recette.SingleOrDefault(r => r.id_recette == 1);
            KitchenToolsController kitchenToolsController = new KitchenToolsController();

            KitchenReceipeController.GetReceipe(receipe);

            Assert.AreEqual(5, couteauCleanQuantityBefore);
            int couteauCleanQuantityAfter = StockEquipement.Instance.Clean["couteau"];
            Assert.AreEqual(3, couteauCleanQuantityAfter);
*/
            //Impossible to test a thread + semaphore method

        }

        [TestMethod]
        public void FreeSemaphReceipeTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

    }
}
