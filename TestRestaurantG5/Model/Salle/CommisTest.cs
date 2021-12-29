using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class CommisTest
    {
        [TestMethod]
        public void TestConstructCommis()
        {
            Commis BasicCommis = new Commis();
            Assert.AreEqual(0, BasicCommis.PosX);
            Assert.AreEqual(0, BasicCommis.PosY);
            Commis PositionedCommis = new Commis(5, 10);
            Assert.AreEqual(5, PositionedCommis.PosX);
            Assert.AreEqual(10, PositionedCommis.PosY);
            Commis WrongPositioningCommis = new Commis(-62, -2);
            Assert.AreEqual(0, WrongPositioningCommis.PosX);
            Assert.AreEqual(0, WrongPositioningCommis.PosY);
        }
    }
}
