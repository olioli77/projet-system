using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class ClientWaiterTest
    {
        [TestMethod]
        public void TestConstructServeur()
        {
            ClientWaiter BasicServeur = new ClientWaiter();
            Assert.AreEqual(0, BasicServeur.PosX);
            Assert.AreEqual(0, BasicServeur.PosY);
            ClientWaiter PositionedServeur = new ClientWaiter(1, 11);
            Assert.AreEqual(1, PositionedServeur.PosX);
            Assert.AreEqual(11, PositionedServeur.PosY);
            ClientWaiter WrongPositioningServeur = new ClientWaiter(-6, -8);
            Assert.AreEqual(0, WrongPositioningServeur.PosX);
            Assert.AreEqual(0, WrongPositioningServeur.PosY);
        }
    }
}
