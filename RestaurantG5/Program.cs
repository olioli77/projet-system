using RestaurantG5.Model.Common;
using System;

namespace RestaurantG5
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            RestaurantLauncher restaurant = new RestaurantLauncher();
            using (var game = restaurant.Game)
                game.Run();
            //Console.WriteLine("Hello World!");
        }
    }
}
