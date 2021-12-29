using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestClientConstruct()
        {
            Client client = new Client();
            Assert.IsNull(client.Entree);
            Assert.IsNull(client.Plate);
            Assert.IsNull(client.Dessert);
            Assert.IsNotNull(client.Strategy);
        }
    }
}
