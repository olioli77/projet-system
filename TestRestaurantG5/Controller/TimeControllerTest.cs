using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using RestaurantG5.Controller;
using RestaurantG5.Model.Common;

namespace TestRestaurantG5
{
    [TestClass]
    public class TimeControllerTest
    {
        [TestMethod]
        public void TestSetGetTime()
        {
            GameTime testGameTime = new GameTime();
            TimerController.SetTime(testGameTime);
            Assert.AreEqual(testGameTime, Timer.Time);
            //
            // TODO: ajoutez ici la logique du test
            //
        }
    }
}
