using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Move;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class IPositionTest
    {
        [TestMethod]
        public void TestChangePosX()
        {
            IPosition Commis = new Commis(5, 10);
            Assert.AreEqual(5, Commis.PosX);
            Assert.AreEqual(10, Commis.PosY);
            Commis.PosX = 15;
            Commis.PosY = 20;
            Assert.AreEqual(15, Commis.PosX);
            Assert.AreEqual(20, Commis.PosY);
            Commis.PosX = -13;
            Commis.PosY = -45;
            Assert.AreEqual(0, Commis.PosX);
            Assert.AreEqual(0, Commis.PosY);
        }
    }
}
