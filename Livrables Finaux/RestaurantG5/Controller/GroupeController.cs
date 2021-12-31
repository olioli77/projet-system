using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RestaurantG5.Model.Common;

namespace RestaurantG5.Controller
{
    public class GroupeController
    {
        public int rate = 32;
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 PosTable;
        public bool isMooving = false;
        public bool start = true;
        public Group group;
        public bool inTable = false;

        public GroupeController(Group groupe)
        {
            Position = new Vector2(6 * rate, 20 * rate);
            group = groupe;
        }

        public void moveToTable(Vector2 finalpos)
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
                inTable = true;
            }

        }
        public void Start(GameTime _gametime)
        {
            if (Position.Y > 16 * rate)
            {
                Position.Y -= 1 * Param.SPEED;
            }
            if (Position.Y == 16 * rate)
            {
                start = false;
            }

        }

        public void Update(GameTime _gametime, Vector2 finalpos)
        {





            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Position.Y == 16 * rate)
            {
                isMooving = true;

            }
            if (isMooving)
            {
                moveToTable(finalpos);
            }
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }

        public static void ChangeGroupState(Group group, GroupState state)
        {
            if ((group != null) && (group.State != state))
                group.State = state;
        }

        public void toto()
        {
            switch (this.group.State)
            {
                case GroupState.WaitTableAttribution:
                    this.start = true;
                    break;

                case GroupState.WaitRankChief:

                    break;

                case GroupState.Ordering:

                    break;

                case GroupState.Ordered:

                    break;

                case GroupState.WaitEntree:

                    break;

                case GroupState.WaitPlate:

                    break;

                case GroupState.WaitDessert:

                    break;

                case GroupState.WaitBill:

                    break;
            }
        }
    }
}
