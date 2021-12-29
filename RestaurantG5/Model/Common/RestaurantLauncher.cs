using RestaurantG5.Controller;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.View;
using System.Collections.Generic;
using System.Threading;

namespace RestaurantG5.Model.Common
{
    public class RestaurantLauncher
    {
        private List<SalleModel> salles;
        private SalleController salleController;
        private KitchenController kitchenController;
        private Game1 game;
        public int speed = 16;
        public List<SalleModel> Salles { get => salles; set => salles = value; }
        public Game1 Game { get => game; set => game = value; }

        public RestaurantLauncher()
        {
            salles = new List<SalleModel>();
            salles.Add(new SalleModel());
            salleController = new SalleController();
            kitchenController = new KitchenController();
            Thread kitchenCommands = new Thread(LaunchKitchenCommands);
            Thread salleCommands = new Thread(LaunchSalleCommandsAsync);
            kitchenCommands.Start();
            salleCommands.Start();
            game = new Game1();
            game.SalleModel = salles[0];
            MapController.UpdateMap();
        }

        private void LaunchKitchenCommands()
        {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            kitchenController.kitchenCommandController.InitSocketServerAsync();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            kitchenController.kitchenCommandController.SocketListen();
        }

        private void LaunchSalleCommandsAsync()
        {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            CommandController.Instance.InitClientSocketAsync();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel. Envisagez d'appliquer l'opérateur 'await' au résultat de l'appel.
            CommandController.Instance.HotelMaster = salles[0].HotelMaster;
            CommandController.Instance.SocketConnect();
        }
    }
}
