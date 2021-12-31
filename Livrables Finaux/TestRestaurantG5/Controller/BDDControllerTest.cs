using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantG5.Controller;
using RestaurantG5.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestRestaurantG5.Controller
{
    [TestClass]
    public class BDDControllerTest
    {
        [TestMethod]
        public void TestConsumeIngredient()
        {
          /*  var DB = BDDController.Instance.DB;
            var stockIngredient = from stock in DB.Stock
                                  where stock.id_Ingredient == 5
                                  select stock;

            var ingredientFromStock = stockIngredient.FirstOrDefault<Stock>();
            var ingredientFromIngredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            int oldQuantity = (int)ingredientFromStock.quantite_stock;
            BDDController.Instance.ConsumeIngredient(ingredientFromIngredient);

            Assert.AreEqual(oldQuantity - 1,
                DB.Stock.Single(ing => ing.id_Ingredient == 5).quantite_stock);

            ingredientFromStock.quantite_stock++;
            DB.SaveChanges();*/
        }

        [TestMethod]
        public void TestGetRecettes()
        {
            var recettes = BDDController.Instance.GetRecettes();
            Assert.IsNotNull(recettes);
            Assert.IsInstanceOfType(recettes, typeof(List<Recette>));
        }

         [TestMethod]
        public void TestAddIngredient()
        {
           /* var DB = BDDController.Instance.DB;
            var ingredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            var stockIngredient = DB.Stock.Single(ing => ing.id_Ingredient == 5);
            int oldStock = (int)stockIngredient.quantite_stock;
            Assert.IsNotNull(stockIngredient);
            BDDController.Instance.AddIngredient(ingredient, 2);
            Assert.AreEqual(oldStock + 2, stockIngredient.quantite_stock);*/
        }

        [TestMethod]
        public void TestRestockIngredient()
        {
           /* var DB = BDDController.Instance.DB;
            var ingredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            var stockIngredient = DB.Stock.Single(ing => ing.id_Ingredient == 5);
            int oldStock = (int)stockIngredient.quantite_stock;
            Assert.IsNotNull(stockIngredient);
            BDDController.Instance.RestockIngredient(ingredient);
            Assert.AreEqual(50, stockIngredient.quantite_stock);*/
        }

        [TestMethod]
        public void TestIngredientDispo()
        {
            var stockIng = BDDController.Instance.DB.Stock.SingleOrDefault(stock => stock.id_Ingredient == 5);
            Console.WriteLine(stockIng == null);
            Assert.AreEqual(stockIng != null, BDDController.Instance.IngredientDispo(5));
        }
    }
}
