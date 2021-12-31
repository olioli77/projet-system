using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Role;

namespace TestRestaurantG5.Model.Cuisine
{
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        public void TestSquareConstruct()
        {
            HotelMaster hotelMaster = new HotelMaster();
            Assert.IsNotNull(hotelMaster.RankChiefs[0].Squares[0].Tables);
            Assert.IsNotNull(hotelMaster.RankChiefs[0].Squares[0].Waiters);
            Assert.AreEqual(Param.TABLES_BY_SQUARE, hotelMaster.RankChiefs[0].Squares[0].Tables.Count);
            Assert.AreEqual(Param.WAITER_BY_SQUARE, hotelMaster.RankChiefs[0].Squares[0].Waiters.Count);
        }
    }
}
