using RestaurantG5.Model.Salle.Role;

namespace RestaurantG5.Model.Salle.Factory
{
    class ClientFactoryB : AbstractClientFactory
    {
        private static ClientFactoryB instance;

        public static ClientFactoryB Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClientFactoryB();
                return Instance;

            }
        }

        private ClientFactoryB() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 2);
            client.Strategy.Add("dessert", 1);
            return client;

            //throw new NotImplementedException();
        }
    }
}
