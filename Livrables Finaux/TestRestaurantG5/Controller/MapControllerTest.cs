using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Controller;
using RestaurantG5.Model.Common;

namespace TestRestaurantG5.Controller
{
    [TestClass]
    public class MapControllerTest
    {
        public void TestGetMap()
        {
            Map map = MapController.GetMap();
            Assert.IsNotNull(map);
            Assert.IsInstanceOfType(map, typeof(Map));
        }

        [TestMethod]
        public void TestReleaseMap()
        {
            Map map = MapController.GetMap();
            Assert.IsNotNull(map);
            Assert.IsInstanceOfType(map, typeof(Map));

            MapController.ReleaseMap();
        }

        [TestMethod]
        public void TestUpdateMap()
        {
            MapController.UpdateMap();
        }
    }
}
