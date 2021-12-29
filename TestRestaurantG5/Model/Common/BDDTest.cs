using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Model.Common;
using System;
using System.Linq;

namespace TestRestaurantG5.Model.Common
{
    [TestClass]
    public class BDDTest
    {
        [TestMethod]
        public void TestConnectBDD()
        {
            using (var db = new BDDRestaurant())
            {
                Assert.IsTrue(db.Database.Exists());
            }
        }

        [TestMethod]
        public void TestShowAndAddAndDeleteFromBDD()
        {
            using (var db = new BDDRestaurant())
            {
                Assert.IsTrue(db.Database.Exists());
                var ustenstiles = from ustensile in db.Ustensile
                                  select ustensile;
                foreach (var ustenstile in ustenstiles)
                {
                    Console.WriteLine(ustenstile.nom_ust_Ustensile);
                }

                Ustensile newUstensile = new Ustensile();
                newUstensile.nom_ust_Ustensile = "test";

                db.Ustensile.Add(newUstensile);
                db.SaveChanges();

                var query = from ustensile in db.Ustensile
                            where ustensile.nom_ust_Ustensile == "test"
                            select ustensile;

                foreach (Ustensile ust in query)
                    db.Ustensile.Remove(ust);
                db.SaveChanges();
            }
        }
    }
}
