using System.Collections.Generic;
using System.Threading;

namespace RestaurantG5.Model.Cuisine
{
    class KitchenPools
    {
#pragma warning disable CS0649 // Le champ 'KitchenPools.ThreadPoolCooker' n'est jamais assigné et aura toujours sa valeur par défaut null
        public static List<Thread> ThreadPoolCooker;
#pragma warning restore CS0649 // Le champ 'KitchenPools.ThreadPoolCooker' n'est jamais assigné et aura toujours sa valeur par défaut null
#pragma warning disable CS0649 // Le champ 'KitchenPools.ThreadPoolDisher' n'est jamais assigné et aura toujours sa valeur par défaut null
        public static List<Thread> ThreadPoolDisher;
#pragma warning restore CS0649 // Le champ 'KitchenPools.ThreadPoolDisher' n'est jamais assigné et aura toujours sa valeur par défaut null

    }
}
