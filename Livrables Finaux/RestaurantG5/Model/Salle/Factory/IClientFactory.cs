using RestaurantG5.Model.Salle.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantG5.Model.Salle.Factory
{
    public interface IClientFactory
    {
        Client CreateClient();
    }
}
