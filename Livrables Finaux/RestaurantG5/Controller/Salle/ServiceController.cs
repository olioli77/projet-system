using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using System;
using System.Collections.Generic;

namespace RestaurantG5.Controller
{
    class ServiceController
    {
        public int tile = 32;
        public Vector2 Position;
        private Vector2 Spawn;
        private Vector2 Clients;
#pragma warning disable CS0414 // Le champ 'ServiceController.lastGroup' est assigné, mais sa valeur n'est jamais utilisée
        private Group lastGroup = null;
#pragma warning restore CS0414 // Le champ 'ServiceController.lastGroup' est assigné, mais sa valeur n'est jamais utilisée
        public Texture2D Texture;
        public bool isMooving = false;
        public bool isCleaning = false;
        public bool toSpawn = false;
        private List<Table> tablesInUse;
        int rdtable;


        public ServiceController(Vector2 fpos)
        {
            this.Position = fpos;
            Spawn = fpos;




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
                toSpawn = false;
            }

        }

        private void cleanTable(List<Table> tables)
        {
            foreach (Table t in tables)
            {
                if (t.State == EquipementState.Dirty)
                {
                    isCleaning = true;
                    moveTo(rectToVect(t.Rect));
                    if (Position == rectToVect(t.Rect))
                    {
                        t.State = EquipementState.Available;
                        toSpawn = true;
                        isCleaning = false;
                    }
                    break;
                }
            }
        }




        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }

        public void Update(GameTime _gametime, List<Table> tables)
        {
            tablesInUse = new List<Table>();
            foreach (Table t in tables)
            {
                if (t.Group != null)
                {
                    tablesInUse.Add(t);

                }
            }



            if (toSpawn)
            {
                moveTo(Spawn);
            }
            else
            {
                cleanTable(tables);

                if (!isCleaning)
                {

                    if (isMooving)
                    {
                        moveTo(Clients);
                        if (Position == Clients)
                        {
                            toSpawn = true;
                        }
                    }
                    else
                    {
                        if (tablesInUse.Count > 0)
                        {
                            Random random = new Random();
                            rdtable = random.Next(0, tablesInUse.Count);
                            Clients = rectToVect(tablesInUse[rdtable].Rect);
                            isMooving = true;
                        }

                    }
                }

            }

        }



        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }
    }
}
