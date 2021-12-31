using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestaurantG5.Model.Common;
using RestaurantG5.Controller;
using RestaurantG5.Controller.Salle;

namespace TestRestaurantG5.Controller
{
    [TestClass]
    public class CommandSocketsTest
    {
        [TestMethod]
#pragma warning disable CS1998 // Cette m�thode async n'a pas d'op�rateur 'await' et elle s'ex�cutera de fa�on synchrone. Utilisez l'op�rateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(�)' pour effectuer un travail utilisant le processeur sur un thread d'arri�re-plan.
        public async Task TestInitConnection()
#pragma warning restore CS1998 // Cette m�thode async n'a pas d'op�rateur 'await' et elle s'ex�cutera de fa�on synchrone. Utilisez l'op�rateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(�)' pour effectuer un travail utilisant le processeur sur un thread d'arri�re-plan.
        {
            Assert.IsFalse(Param.KITCHEN_SERVER_STARTED);
            KitchenCommandController server = new KitchenCommandController();
#pragma warning disable CS4014 // Dans la mesure o� cet appel n'est pas attendu, l'ex�cution de la m�thode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'op�rateur 'await' au r�sultat de l'appel.
            server.InitSocketServerAsync();
#pragma warning restore CS4014 // Dans la mesure o� cet appel n'est pas attendu, l'ex�cution de la m�thode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'op�rateur 'await' au r�sultat de l'appel.
            Assert.IsTrue(Param.KITCHEN_SERVER_STARTED);

            Assert.IsFalse(Param.SALLE_CLIENT_STARTED);
            CommandController client = new CommandController();
#pragma warning disable CS4014 // Dans la mesure o� cet appel n'est pas attendu, l'ex�cution de la m�thode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'op�rateur 'await' au r�sultat de l'appel.
            client.InitClientSocketAsync();
#pragma warning restore CS4014 // Dans la mesure o� cet appel n'est pas attendu, l'ex�cution de la m�thode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'op�rateur 'await' au r�sultat de l'appel.
            Assert.IsTrue(Param.SALLE_CLIENT_STARTED);
        }
    }
}
