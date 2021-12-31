using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Common;

namespace TestRestaurantG5
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void TestMapSingleton()
        {
            Map map = Map.Instance;
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void TestMapConstruct()
        {
            Map map = Map.Instance;
            Assert.IsNotNull(map);
            Assert.IsNotNull(map.Recettes);
        }
    }
}
