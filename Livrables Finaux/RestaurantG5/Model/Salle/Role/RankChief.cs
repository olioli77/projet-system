using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.Model.Salle.Move;
using System.Collections.Generic;

namespace RestaurantG5.Model.Salle.Role
{
    public class RankChief : Position, IMove
    {
        private List<Square> squares;
        public Vector2 FPosition;
        public Vector2 Position;
        private bool available = true;
        public int rate = 32;
        public Texture2D Texture;
        public bool isMooving = false;
        public bool toSpawn = false;






        public List<Square> Squares { get => squares; set => squares = value; }
        public bool Available { get => available; set => available = value; }

        public RankChief()
        {
            this.squares = new List<Square>();
            this.squares.Add(new Square());

        }
        public RankChief(Vector2 Position)
        {
            this.FPosition = Position;
            this.Position = Position;
            this.squares = new List<Square>();
            this.squares.Add(new Square());


        }

        public RankChief(int posX, int posY) : base(posX, posY)
        {
            this.squares = new List<Square>();
            this.squares.Add(new Square());
        }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }



        public int findGoodTable(int nbpersonnes)
        {
            foreach (Table table in this.squares[0].Tables)
            {
                if (table.State == EquipementState.Available)
                {

                }
            }
            return 0;
        }


        public void Update(GameTime _gametime, Vector2 finalpos)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Position.Y == 16 * rate)
            {
                isMooving = true;

            }
            if (isMooving)
            {
                available = false;
                moveTo(finalpos);
            }
            if (toSpawn)
            {
                available = false;
                moveTo(FPosition);
            }
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



            if (Position == finalpos)
            {
                isMooving = false;
                toSpawn = true;
            }
            if (Position == FPosition)
            {
                toSpawn = false;
                available = true;
            }

        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }
    }
}
