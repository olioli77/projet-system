using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RestaurantG5.Model.Common;

namespace RestaurantG5.Controller.Salle
{
    class PlongeController
    {
        public int tile = 32;
        public Vector2 Position;
        public Texture2D Texture;
        public bool isMooving = false;

        public PlongeController()
        {
            this.Position = new Vector2(28 * tile, 21 * tile);
        }

        public void moveTo(Vector2 finalpos)
        {

            if (Position.X > finalpos.X)
            {
                Position.X -= 1 * Param.SPEED;
            }
            if (Position.X < finalpos.X)
            {
                Position.X += 1 * Param.SPEED;
            }
            if (Position.Y > finalpos.Y)
            {
                Position.Y -= 1 * Param.SPEED;
            }
            if (Position.Y < finalpos.Y)
            {
                Position.Y += 1 * Param.SPEED;
            }

            if (Position.Y == finalpos.Y && Position.X == finalpos.X)
            {
                isMooving = false;
            }

        }

        public void Update(GameTime _gametime)
        {


        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }
    }
}
