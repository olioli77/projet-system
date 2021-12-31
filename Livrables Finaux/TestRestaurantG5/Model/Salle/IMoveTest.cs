using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class IMoveTest
    {
        [TestMethod]
        public void TestMove()
        {
            Commis commis = new Commis(2, 4);
            Assert.AreEqual(2, commis.PosX);
            Assert.AreEqual(4, commis.PosY);
            commis.Move(4, 8);
            Assert.AreEqual(4, commis.PosX);
            Assert.AreEqual(8, commis.PosY);
            commis.Move(-2, -10);
            Assert.AreEqual(0, commis.PosX);
            Assert.AreEqual(0, commis.PosY);
        }
    }
}
