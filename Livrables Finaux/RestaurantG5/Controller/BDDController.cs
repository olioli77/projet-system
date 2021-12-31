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
                    if (result.quantite_stock > 0)
                    {
                        result.quantite_stock--;
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
                stockIngredient.quantite_stock = 50;
                DB.SaveChanges();
            }
        }

        public void AddIngredient(Ingredient ingredient, int number)
        {
            var stockIngredient = DB.Stock.Single(stock => stock.id_Ingredient == ingredient.id_Ingredient);
            if (stockIngredient != null)
            {
                stockIngredient.quantite_stock += number;
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
                if (stockStep.quantite_stock > 0)
                    return true;
            return false;
        }
    }
}
