using RestaurantG5.Model.Common;
using System.Threading;

namespace RestaurantG5.Controller
{
   public class EventHandler
    {
        private static EventHandler instance;

        private EventHandler() { }

        public static EventHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventHandler();
                return instance;
            }
        }

        public void Update(Group group)
        {
            switch (group.State)
            {
                case GroupState.WaitPlate:
                    CommandController.ConnectAndSendCommand(group);

                    break;
                case GroupState.WaitDessert:
                    CommandController.ConnectAndSendCommand(group);

                    break;
            }
        }

        private void UpdateCallBack()
        {
            Thread.Sleep(2000);
        }
    }
}
