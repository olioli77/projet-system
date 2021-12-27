using System.Collections.Generic;

namespace RestaurantG5.Model.Common
{
    class Map
    {
        private static Map instance;
        private List<Recette> recettes;

        public static Map Instance
        {
            get
            {
                if (instance == null)
                    instance = new Map();
                return instance;
            }
        }

        private Map()
        {
            this.recettes = new List<Recette>();
        }

        public List<Recette> Recettes { get => recettes; set => recettes = value; }
    }
}
