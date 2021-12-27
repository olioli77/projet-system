using RestaurantG5.Model.Salle.Move;

namespace RestaurantG5.Model.Salle.Role
{
    public class ClientWaiter : Position, IMove
    {
        public ClientWaiter(int posX, int posY) : base(posX, posY)
        {
        }
        public ClientWaiter() : base() { }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
