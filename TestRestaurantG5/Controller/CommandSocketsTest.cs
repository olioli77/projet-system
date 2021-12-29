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
#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        public async Task TestInitConnection()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        {
            Assert.IsFalse(Param.KITCHEN_SERVER_STARTED);
            KitchenCommandController server = new KitchenCommandController();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            server.InitSocketServerAsync();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            Assert.IsTrue(Param.KITCHEN_SERVER_STARTED);

            Assert.IsFalse(Param.SALLE_CLIENT_STARTED);
            CommandController client = new CommandController();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            client.InitClientSocketAsync();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            Assert.IsTrue(Param.SALLE_CLIENT_STARTED);
        }
    }
}
