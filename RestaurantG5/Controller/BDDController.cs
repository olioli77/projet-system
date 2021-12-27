using RestaurantG5.Model.Common;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantG5.Controller
{
    public class BDDController
    {
        private static BDDController instance;

        private BDDController()
        {
            this.InitConnection();
        }

        public static BDDController Instance
        {
            get
            {
                if (instance == null)
                    instance = new BDDController();
                return instance;
            }
        }

        public BDDRestaurant DB;

        public void InitConnection()
        {
            DB = new BDDRestaurant();
        }

        public void CloseConnection()
        {
            DB.Dispose();
        }

        public void ConsumeIngredient(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                if (DB.Ingredient.Find(ingredient.id_Ingredient) != null)
                {
                    var result = DB.Stock.SingleOrDefault(stock => stock.id_Ingredient == ingredient.id_Ingredient);
                    if (result.quantité_Stock > 0)
                    {
                        result.quantité_Stock--;
                    }
                    DB.SaveChanges();
                }
            }
        }

        public void RestockIngredient(Ingredient ingredient)
        {
            var stockIngredient = DB.Stock.Single(stock => stock.id_Ingredient == ingredient.id_Ingredient);
            if (stockIngredient != null)
            {
                stockIngredient.quantité_Stock = 50;
                DB.SaveChanges();
            }
        }

        public void AddIngredient(Ingredient ingredient, int number)
        {
            var stockIngredient = DB.Stock.Single(stock => stock.id_Ingredient == ingredient.id_Ingredient);
            if (stockIngredient != null)
            {
                stockIngredient.quantité_Stock += number;
                DB.SaveChanges();
            }
        }

        public List<Recette> GetRecettes()
        {
            var recettes = DB.Recette.ToList<Recette>();
            if (recettes != null)
                return recettes;
            return null;
        }

        public bool IngredientDispo(int id_ingredient)
        {
            var stockStep = DB.Stock.SingleOrDefault<Stock>(ing => ing.id_Ingredient == id_ingredient);
            if (stockStep != null)
                if (stockStep.quantité_Stock > 0)
                    return true;
            return false;
        }
    }
}
