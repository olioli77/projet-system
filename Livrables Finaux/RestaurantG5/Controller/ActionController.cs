using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RestaurantG5.Model.Common;

namespace RestaurantG5.Controller
{
    public class ActionController
    {
        private Vector2 PositionX1;
        private Vector2 PositionX16;
        private Vector2 PositionPause;
        public Texture2D TextureX1;
        public Texture2D TextureX16;
        public Texture2D TexturePause;
        private Rectangle rectX1;
        private Rectangle rectX16;
        private Rectangle rectPause;





        public ActionController()
        {

            PositionPause = new Vector2(1500, 860);
            PositionX16 = new Vector2(1390, 860);
            PositionX1 = new Vector2(1280, 860);
            rectX1 = new Rectangle(1280, 860, 100, 100);
            rectX16 = new Rectangle(1390, 860, 100, 100);
            rectPause = new Rectangle(1500, 860, 100, 100);
        }




        public void Update(GameTime _gametime, MouseState Mstate)
        {

            if (Mstate.LeftButton == ButtonState.Pressed)
            {
                if (isInRect(Mstate, rectX1))
                {
                    Param.SPEED = 1;
                    System.Console.WriteLine("Vitesse X1");
                }
                if (isInRect(Mstate, rectX16))
                {
                    Param.SPEED = 16;
                    System.Console.WriteLine("Vitesse X16");
                }
                if (isInRect(Mstate, rectPause))
                {
                    Param.SPEED = 0;
                    System.Console.WriteLine("PAUSE");
                }
            }


        }

        private bool isInRect(MouseState Mstate, Rectangle rect)
        {
            return (Mstate.X >= rect.Left && Mstate.X <= rect.Right && Mstate.Y >= rect.Top && Mstate.Y <= rect.Bottom);
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(TexturePause, PositionPause, Color.White);
            _spritBash.Draw(TextureX16, PositionX16, Color.White);
            _spritBash.Draw(TextureX1, PositionX1, Color.White);
        }
    }
}
