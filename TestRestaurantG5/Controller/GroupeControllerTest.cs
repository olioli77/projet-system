using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using RestaurantG5.Controller;
using RestaurantG5.Model.Common;

namespace TestRestaurantG5
{
    [TestClass]
    public class GroupeControllerTest
    {
        public class TestGroupe
        {
            GroupeController Tgroupe = new GroupeController(new Group());


            public TestGroupe()
            {

            }

            #region Attributs de tests supplémentaires
            //
            // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
            //
            // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
            // [ClassInitialize()]
            // public static void MyClassInitialize(TestContext testContext) { }
            //
            // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
            // [ClassCleanup()]
            // public static void MyClassCleanup() { }
            //
            // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
            // [TestInitialize()]
            // public void MyTestInitialize() { }
            //
            // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
            // [TestCleanup()]
            // public void MyTestCleanup() { }
            //
            #endregion

            [TestMethod]
            public void TestConstruct()
            {

                Assert.AreEqual(Tgroupe.Position, new Vector2(192, 640));
            }



            [TestMethod]
            public void TestmoveToTable()
            {
                Tgroupe.isMooving = true;
                while (Tgroupe.isMooving)
                {
                    Tgroupe.moveToTable(new Vector2(0, 0));
                }

                Assert.AreEqual(Tgroupe.Position, new Vector2(0, 0));
            }


            [TestMethod]
            public void TestStart()
            {
                Tgroupe.start = true;
                GameTime _gametime = new GameTime();
                while (Tgroupe.start)
                {
                    Tgroupe.Start(_gametime);
                }

                Assert.AreEqual(Tgroupe.Position.Y, 512);
            }

            [TestMethod]
            public void TestChangeGroupState()
            {
                Group group = new Group();
                Assert.AreEqual(GroupState.WaitTableAttribution, group.State);
                GroupeController.ChangeGroupState(group, GroupState.WaitRankChief);
                Assert.AreEqual(GroupState.WaitRankChief, group.State);
            }
        }
    }
}
