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

            #region Attributs de tests suppl�mentaires
            //
            // Vous pouvez utiliser les attributs suppl�mentaires suivants lorsque vous �crivez vos tests�:
            //
            // Utilisez ClassInitialize pour ex�cuter du code avant d'ex�cuter le premier test de la classe
            // [ClassInitialize()]
            // public static void MyClassInitialize(TestContext testContext) { }
            //
            // Utilisez ClassCleanup pour ex�cuter du code une fois que tous les tests d'une classe ont �t� ex�cut�s
            // [ClassCleanup()]
            // public static void MyClassCleanup() { }
            //
            // Utilisez TestInitialize pour ex�cuter du code avant d'ex�cuter chaque test 
            // [TestInitialize()]
            // public void MyTestInitialize() { }
            //
            // Utilisez TestCleanup pour ex�cuter du code apr�s que chaque test a �t� ex�cut�
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
