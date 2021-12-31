using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5;
using RestaurantG5.Controller;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Controller
{
    [TestClass]
    public class TableControllerTest
    {
        [TestMethod]
        public void TestAttributionTableGroup()
        {
            /*HotelMaster hotelMaster = new HotelMaster();
            HomeController welcomeController = new HomeController(hotelMaster);
            Group group = welcomeController.CreateGroup(5);
            TableController tableController = new TableController();
            Table table = tableController.OptimizedFindTable(hotelMaster.RankChiefs[0].Squares[0].Tables, group.Clients.Count);
            if (table == null)
                table = tableController.OptimizedFindTable(hotelMaster.RankChiefs[1].Squares[0].Tables, group.Clients.Count);
            Assert.IsNotNull(table);
            bool success = tableController.AttributionTableGroup(group, table);
            Assert.IsTrue(success);
            Assert.AreEqual(EquipementState.InUse, table.State);
            Assert.AreEqual(GroupState.Ordering, group.State);*/
        }

        [TestMethod]
        public void TestCleanTable()
        {
            Table table = new Table(10);
            Assert.AreEqual(EquipementState.Available, table.State);

            table.State = EquipementState.InUse;
            TableController.CleanTable(table);
            Assert.AreEqual(EquipementState.InUse, table.State);

            table.State = EquipementState.Dirty;
            TableController.CleanTable(table);
            Assert.AreEqual(EquipementState.Available, table.State);
        }

        [TestMethod]
        public void TestDriveGroupTable()
        {
            Table table = new Table(10, 64, 64);
            table.State = EquipementState.InUse;
            RankChief rankChief = new RankChief(32, 32);
            rankChief.Squares[0].Tables.Add(table);

            TableController tableController = new TableController();
            tableController.DriveGroupTable(table, rankChief);
            Assert.IsNull(table.Group);
            Assert.AreEqual(32, rankChief.PosX);
            Assert.AreEqual(32, rankChief.PosY);

            Group group = new Group(128, 128);
            Assert.IsNotNull(group);
            table.Group = group;
            Assert.IsNotNull(table.Group);
            tableController.DriveGroupTable(table, rankChief);
            Assert.AreEqual(table.PosX - 32, rankChief.PosX);
            Assert.AreEqual(table.PosY, rankChief.PosY);
            Assert.AreEqual(table.PosX, group.PosX);
            Assert.AreEqual(table.PosY, group.PosY);
        }

        [TestMethod]
        public void TestRestock()
        {
            Group group = new Group();
            Table table = new Table(8)
            {
                State = EquipementState.InUse,
                Group = group
            };
            Assert.AreEqual(40, StockEquipement.Instance.Clean["BreadBasket"]);

            bool value = TableController.Restock(table);
            Assert.IsTrue(value);
            Assert.AreEqual(39, StockEquipement.Instance.Clean["BreadBasket"]);

        }
    }
}
