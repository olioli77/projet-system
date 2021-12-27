using RestaurantG5.Model.Common;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace RestaurantG5.Controller.Cuisine
{
    public class KitchenReceipeController
    {
        //Init the semahpore who represent cookers (2)
        public static Semaphore _cooker = new Semaphore(2, 2);

        private static void CookCallback(Object step, Object paramUstensile)
        {

            //Cast the good type
            Etape actualStep = (Etape)step;
            Ustensile ustensile = (Ustensile)paramUstensile;

            //Init a kitchenController
            KitchenToolsController kitchenToolsController = new KitchenToolsController();
            //Try to get the tool
            kitchenToolsController.SetInUseTool(ustensile.nom_ust_Ustensile);

            //Take one permit on Semaphore
            _cooker.WaitOne();

            //Clear stock
            //BDDController.Instance.DB.Stock.Remove...

            //Sleep represent the time of the step
            Thread.Sleep(Convert.ToInt32(actualStep.temps_etape) * 1000);

            //When step is done, semaphore is release. Cooker is free.
            _cooker.Release(1);
        }

        public static void GetReceipe(Object recette)
        {
            Recette receipe = (Recette)recette;
            //Explode the steps from the receipe in an array
            string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");

            //Foreach step in the steps array
            foreach (var step in steps)
            {


                int stepId = Convert.ToInt32(step);

                //From BDD we get all objects needed
                compose actualCompose = BDDController.Instance.DB.compose.SingleOrDefault(c => c.id_compose == stepId);
                Etape actualStep = BDDController.Instance.DB.Etape.SingleOrDefault(e => e.id_etape == actualCompose.id_etape);
                Console.WriteLine(actualCompose.id_Ingredient);
                Ustensile ustensile = BDDController.Instance.DB.Ustensile.SingleOrDefault(e => e.id_Ustensile == actualStep.id_Ustensile);
                LoggerController.AppendLineToFile(Param.LOG_PATH, actualCompose.id_etape.ToString());

                //Foreach steps in the receipe we create a new thread.
                Thread t = new Thread(delegate ()
                {
                    //We use the method ass call back function of the thread.
                    //Two arg sent : step and ustensile object
                    CookCallback(actualStep, ustensile);
                });

                //Start the thread
                t.Start();
            }

        }

        ////This method verify if all ustensiles used in the receipe are free
        //public static bool VerifyDispoTool(Recette receipe)
        //{
        //    KitchenToolsController kitchenToolsController = new KitchenToolsController();

        //    string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");
        //    foreach (var step in steps)
        //    {
        //        int actualStepID = Convert.ToInt32(step);

        //        try
        //        {
        //            composé actualCompose = BDDController.Instance.DB.composé.SingleOrDefault(r => r.id_compose == actualStepID);
        //            Etape actualStep = BDDController.Instance.DB.Etape.SingleOrDefault(r => r.id_etape == actualCompose.id_etape);
        //            Ustensile actualStepTool = BDDController.Instance.DB.Ustensile.SingleOrDefault(r => r.id_Ustensile == actualStep.id_Ustensile);
        //            string toolName = actualStepTool.nom_ust_Ustensile;

        //            if (kitchenToolsController.VerifyStock(toolName, 1))
        //            {

        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        catch
        //        {
        //            return false;
        //        }

        //    }
        //    return true;
        //}
    }
}
