using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Role;
using System;
using System.Collections.Generic;
using RestaurantG5.Controller;

namespace TestRestaurantG5
{
    [TestClass]
    public class HomeControllerTest
    {
        HotelMaster hotelMaster;
        HomeController homeController;
       
        [TestInitialize]
        public void SetUp()
        {
            hotelMaster = new HotelMaster(30, 40);
            homeController = new HomeController(hotelMaster);
        }

        [TestMethod]
        public void TestGenerateClient()
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < 100000; i++)
            {
                clients.Add(homeController.GenerateClient());
                Assert.IsNotNull(clients[i]);
                Assert.IsInstanceOfType(clients[i], typeof(Client));
            }
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(0)));
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(1)));
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(2)));
        }

        [TestMethod]
        public void TestCreateGroup()
        {
            Group group = homeController.CreateGroup(4);
            Assert.AreEqual(4, group.Clients.Count);
        }

        [TestMethod]
        public void TestCheckAvailableTables()
        {
            Group group = homeController.CreateGroup(7);
            Assert.IsTrue(homeController.CheckAvailableTables(group));
            group = homeController.CreateGroup(11);
            Assert.IsFalse(homeController.CheckAvailableTables(group));
        }

        [TestMethod]
        public void TestCallRankChief()
        {
            Group group = homeController.CreateGroup(5);
            hotelMaster.RankChiefs[0].Squares[0].Tables[4].Group = group;
            RankChief designatedRankChief = homeController.FindRankChief(group);
            Assert.AreEqual(hotelMaster.RankChiefs[0], designatedRankChief);
            homeController.CallRankChief(designatedRankChief);
            Assert.AreEqual(hotelMaster.PosX - 10, designatedRankChief.PosX);
            Console.WriteLine(hotelMaster.PosY);
            Console.WriteLine(designatedRankChief.PosY);
            Assert.AreEqual(hotelMaster.PosY, designatedRankChief.PosY);
        }
    }
}
