using RestaurantG5.Model.Salle.Move;

namespace RestaurantG5.Model.Salle.Role
{
   public class Commis : Position, IMove
    {
        public Commis(int posX, int posY) : base(posX, posY) { }
        public Commis() : base() { }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
