using RestaurantG5.Controller;
using RestaurantG5.Model.Salle.Role;
using RestaurantG5.Model.Salle.Move;
using System.Collections.Generic;

namespace RestaurantG5.Model.Common
{
    public enum GroupState
    {
        WaitTableAttribution,
        WaitRankChief,
        Ordering,
        TableDispose,
        Ordered,
        WaitEntree,
        WaitPlate,
        WaitDessert,
        WaitBill,
        Dead
    };

    public class Group : Position, IMove
    {
        private int id;
        private List<Client> clients;
        private GroupState state;
        private static int GroupCounter = 1;

        public int ID { get => id; set => id = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public GroupState State { get => state; set => state = value; }

        public Group() : base()
        {
            this.clients = new List<Client>();
            this.id = GroupCounter;
            GroupCounter++;
            this.state = GroupState.WaitTableAttribution;
        }

        public Group(int posX, int posY) : base(posX, posY)
        {
            this.clients = new List<Client>();
            this.id = GroupCounter;
            GroupCounter++;
            this.state = GroupState.WaitTableAttribution;
        }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public void Notify()
        {
            EventHandler.Instance.Update(this);
        }
    }
}
