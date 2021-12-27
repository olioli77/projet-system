using Microsoft.Xna.Framework;
using RestaurantG5.Model.Common;

namespace RestaurantG5.Controller
{
    public class TimerController
    {
        private static GameTime time;
        public TimerController() { }
        private static int temps, lastSec, currentSec = 0;

        public static void SetTime(GameTime timeParam)
        {
            Timer.Time = timeParam;
        }

        public static GameTime GetGameTime()
        {
            return Timer.Time;
        }

        public static int GetTimer()
        {


            lastSec = currentSec;
            currentSec = Timer.Time.TotalGameTime.Seconds;
            if (lastSec != currentSec)
            {
                temps += 1 * Param.SPEED;
            }
            return temps;
        }

        public static GameTime Time { get => time; set => time = value; }
    }
}
