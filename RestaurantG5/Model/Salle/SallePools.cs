using System.Collections.Generic;
using System.Threading;

namespace RestaurantG5.Model.Salle
{
   public class SallePools
    {
        public static Thread ThreadPoolRankChief;
        public static Thread ThreadPoolService;
        public static List<Thread> ThreadPoolHotelMaster;
        public static List<Thread> ThreadPoolCommis;
    }
}
