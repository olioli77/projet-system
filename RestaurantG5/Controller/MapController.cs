using RestaurantG5.Model.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;

namespace RestaurantG5.Controller
{
    public class MapController
    {
        public static Semaphore MapSemaphore = new Semaphore(initialCount: Param.MAP_NUMBER, maximumCount: Param.MAP_NUMBER);

        public static Map GetMap()
        {
            MapSemaphore.WaitOne();
            return Map.Instance;
        }

        public static void ReleaseMap()
        {
            MapSemaphore.Release();
        }

        public static void UpdateMap()
        {
            BDDController bDDController = BDDController.Instance;
            var recettes = bDDController.GetRecettes();
            List<Recette> recettesDispo = new List<Recette>();
            List<int> stepsToCheck;
            bool recetteAvailable;
            foreach (var recette in recettes)
            {
                recetteAvailable = true;
                stepsToCheck = GetSteps(recette.liste_etapes_recette);
                foreach (var step in stepsToCheck)
                {
                    var stepIng = BDDController.Instance.DB.compose.SingleOrDefault<compose>(comp => comp.id_compose == step).id_Ingredient;
                    if ((bDDController.IngredientDispo((int)stepIng)) == false)
                        recetteAvailable = false;
                }

                if (recetteAvailable == true)
                    recettesDispo.Add(recette);
            }
            Map.Instance.Recettes = recettesDispo;
        }

        public static List<int> GetSteps(string rawSteps)
        {
            List<int> steps = new List<int>();
            string[] separatedRawSteps = rawSteps.Split(';');
            foreach (var step in separatedRawSteps)
            {
                steps.Add(int.Parse(step));
            }
            return steps;
        }
    }
}
