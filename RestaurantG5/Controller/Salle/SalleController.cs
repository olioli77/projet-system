namespace RestaurantG5.Controller
{
    class SalleController
    {
        private CommandController commandsController = new CommandController();

#pragma warning disable CS0649 // Le champ 'SalleController.CommandsController' n'est jamais assigné et aura toujours sa valeur par défaut null
        public CommandController CommandsController;
#pragma warning restore CS0649 // Le champ 'SalleController.CommandsController' n'est jamais assigné et aura toujours sa valeur par défaut null
    }
}
