using RestaurantG5.Model.Salle.Role;

namespace RestaurantG5.Model.Salle.Factory
{
    class ClientFactoryA : AbstractClientFactory
    {
        private static ClientFactoryA instance;

        public static ClientFactoryA Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClientFactoryA();
                return Instance;

            }
        }

        private ClientFactoryA() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 1);
            client.Strategy.Add("dessert", 0);
            return client;

                //throw new NotImplementedException();
        }
    }
}
