using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using RestaurantG5.Controller;

namespace TestRestaurantG5
{
    [TestClass]
    public class ParamControllerTest
    {

        [TestMethod]
        public void TestGetValueOrDefault()
        {
            var value = ConfigurationManager.AppSettings["speed"];
            Assert.IsNotNull(value);

            string result = ParamController.GetValueOrDefault("test", "TestValue");
            Assert.AreEqual("TestValue", result);

            result = ParamController.GetValueOrDefault("speed", "10");
            Assert.AreEqual("1", result);

            result = ParamController.GetValueOrDefault("MAP_NUMBER", "16", numericalValue: true);
            var numericalResult = Int32.Parse(result);
            Assert.AreEqual(40, numericalResult);

            result = ParamController.GetValueOrDefault("SALLE_CLIENT_LOCAL_IP", "10", true);
            Assert.AreEqual("10", result);
        }
    }
    
}
