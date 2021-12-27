using RestaurantG5.Model.Salle.Role;

namespace RestaurantG5.Model.Salle.Factory
{
    public abstract class AbstractClientFactory : IClientFactory
    {
        public abstract Client CreateClient();
    }
}
