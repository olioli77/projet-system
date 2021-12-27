using Microsoft.Xna.Framework;

namespace RestaurantG5.Model.Common
{
    public static class Timer
    {
        private static GameTime time;

        public static GameTime Time { get => time; set => time = value; }
    }
}
