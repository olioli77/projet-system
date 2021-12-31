using System.Collections.Generic;

namespace RestaurantG5.Model.Salle.Components
{
    public class StockEquipement
    {
        private Dictionary<string, int> clean;
        private Dictionary<string, int> dirty;
        private Dictionary<string, int> inUse;
        private Dictionary<string, int> washing;
        private static StockEquipement instance;
        private static readonly object padlock = new object();

        public Dictionary<string, int> Clean { get => clean; set => clean = value; }
        public Dictionary<string, int> Dirty { get => dirty; set => dirty = value; }
        public Dictionary<string, int> InUse { get => inUse; set => inUse = value; }
        public Dictionary<string, int> Washing { get => washing; set => washing = value; }


        public static StockEquipement Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StockEquipement();
                    }
                    return instance;
                }
            }
        }

        public static void ResetInstance()
        {
            instance = null;
        }

        private StockEquipement()
        {
            this.clean = new Dictionary<string, int>();
            this.dirty = new Dictionary<string, int>();
            this.inUse = new Dictionary<string, int>();
            this.washing = new Dictionary<string, int>();

            this.clean.Add("BreadBasket", 40);
            this.clean.Add("EntreePlate", 150);
            this.clean.Add("MainPlate", 150);
            this.clean.Add("DessertPlate", 150);
            this.clean.Add("fork", 150);
            this.clean.Add("knife", 150);
            this.clean.Add("soupSpoon", 150);
            this.clean.Add("glass", 150);
            this.clean.Add("tablecloth", 40);
            this.clean.Add("towel", 150);
            this.clean.Add("teaspoon", 150);

            this.dirty.Add("BreadBasket", 0);
            this.dirty.Add("EntreePlate", 0);
            this.dirty.Add("MainPlate", 0);
            this.dirty.Add("DessertPlate", 0);
            this.dirty.Add("fork", 0);
            this.dirty.Add("knife", 0);
            this.dirty.Add("soupSpoon", 0);
            this.dirty.Add("glass", 0);
            this.dirty.Add("tablecloth", 0);
            this.dirty.Add("towel", 0);
            this.dirty.Add("teaspoon", 0);

            this.inUse.Add("BreadBasket", 0);
            this.inUse.Add("EntreePlate", 0);
            this.inUse.Add("MainPlate", 0);
            this.inUse.Add("DessertPlate", 0);
            this.inUse.Add("fork", 0);
            this.inUse.Add("knife", 0);
            this.inUse.Add("soupSpoon", 0);
            this.inUse.Add("glass", 0);
            this.inUse.Add("tablecloth", 0);
            this.inUse.Add("towel", 0);
            this.inUse.Add("teaspoon", 0);

            this.washing.Add("BreadBasket", 0);
            this.washing.Add("EntreePlate", 0);
            this.washing.Add("MainPlate", 0);
            this.washing.Add("DessertPlate", 0);
            this.washing.Add("fork", 0);
            this.washing.Add("knife", 0);
            this.washing.Add("soupSpoon", 0);
            this.washing.Add("glass", 0);
            this.washing.Add("tablecloth", 0);
            this.washing.Add("towel", 0);
            this.washing.Add("teaspoon", 0);
        }

        public bool SubstractEquipement(string equipement)
        {
            bool exist = this.clean.TryGetValue(equipement, out int eNumber);
            if ((exist) && (eNumber > 0))
            {
                this.clean[equipement] = eNumber - 1;
                return true;
            }
            return false;
        }
    }
}
