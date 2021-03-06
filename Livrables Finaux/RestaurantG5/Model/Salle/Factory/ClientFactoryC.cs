using RestaurantG5.Model.Salle.Role;

namespace RestaurantG5.Model.Salle.Factory
{
    public class ClientFactoryC : AbstractClientFactory
    {
        private static ClientFactoryC instance;

        public static ClientFactoryC Instance
        {
            get
            {
                if (instance == null)
                    instance = new ClientFactoryC();
                return instance;

            }
        }

        private ClientFactoryC() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 0);
            client.Strategy.Add("dessert", 0);
            return client;

            //throw new NotImplementedException();
        }
    }
}
