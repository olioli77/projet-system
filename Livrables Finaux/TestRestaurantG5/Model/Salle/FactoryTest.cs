using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Salle.Factory;
using RestaurantG5.Model.Salle.Role;
using RestaurantG5.Model.Common;

namespace TestRestaurantG5.Model.Salle
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void TestHurriedClientFactoryC()
        {
            ClientFactoryC factory = ClientFactoryC.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(0, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void TestNormalClientFactoryA()
        {
            ClientFactoryA factory = ClientFactoryA.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(1, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void TestCoolClientFactoryB()
        {
            ClientFactoryB factory = ClientFactoryB.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(2, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(1, value);
        }
    }
}
