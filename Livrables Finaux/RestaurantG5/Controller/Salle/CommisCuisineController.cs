using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RestaurantG5.Model.Common;
using System;
using System.Collections.Generic;

namespace RestaurantG5.Controller.Salle
{
    class CommisCuisineController
    {
        public int tile = 32;
        public Vector2 Position;
        public Texture2D Texture;
        public bool isMooving = false;
        private List<Vector2> diffpos;
        int randomNumber = 0;

        public CommisCuisineController()
        {
            this.Position = new Vector2(17 * tile, 25 * tile);
            diffpos = new List<Vector2>();
            diffpos.Add(new Vector2(17 * tile, 25 * tile));
            diffpos.Add(new Vector2(20 * tile, 25 * tile));
            diffpos.Add(new Vector2(17 * tile, 26 * tile));
            diffpos.Add(new Vector2(20 * tile, 26 * tile));
            diffpos.Add(new Vector2(17 * tile, 26 * tile));
            diffpos.Add(new Vector2(15 * tile, 26 * tile));
            diffpos.Add(new Vector2(17 * tile, 23 * tile));
            diffpos.Add(new Vector2(20 * tile, 23 * tile));





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



        public void Update(GameTime _gametime, bool inTable)
        {





            if (isMooving && inTable)
            {
                moveTo(diffpos[randomNumber]);
            }
            else
            {
                Random random = new Random();
                randomNumber = random.Next(0, (diffpos.Count - 1));
                isMooving = true;

            }
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }
    }
}
