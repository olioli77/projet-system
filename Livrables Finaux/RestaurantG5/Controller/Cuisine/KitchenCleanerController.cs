using RestaurantG5.Model.Cuisine;
using RestaurantG5.Model.Salle.Components;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;


namespace RestaurantG5.Controller.Cuisine
{
    public static class KitchenCleanerController
    {
        private static Dictionary<string, int> toWashLaundry = new Dictionary<string, int>();
        private static Dictionary<string, int> toWashDishes = new Dictionary<string, int>();

        private static Semaphore _cleaner = new Semaphore(2, 2);

        private static void Wash(Object obj)
        {
            _cleaner.WaitOne();
            int time = (int)obj;
            Thread.Sleep(time);
            _cleaner.Release(1);

        }

        public static void InitSocketServer()
        {
            //
        }

        public static void stock(Dictionary<string, int> dirty)
        {
            foreach (KeyValuePair<string, int> elem in dirty)
            {
                int temp;
                if (StockEquipement.Instance.Clean.TryGetValue(elem.Key, out temp))
                {
                    if (elem.Key == "tablecloth" || elem.Key == "towel")
                    {
                        toWashLaundry[elem.Key] += elem.Value;
                        checkLaundry();
                    }
                    else
                    {
                        toWashDishes[elem.Key] += elem.Value;
                        checkDishes();
                    }
                }
            }
        }

        public static void checkCleaning()
        {
            checkDishes();
            checkLaundry();
        }

        public static void washTools(KeyValuePair<string, Semaphore> param)
        {

            Thread.Sleep(1000);
            StockKitchenWare.Instance.Stock[param.Key].Release();

        }

        private static void checkLaundry()
        {
            int total = 0;
            foreach (KeyValuePair<string, int> elem in StockEquipement.Instance.Dirty)
            {
                if (elem.Key == "towel")
                {
                    toWashLaundry["towel"] += elem.Value;
                    total += elem.Value;
                }
                if (elem.Key == "tablecloth")
                {
                    toWashLaundry["tablecloth"] += elem.Value;
                    total += elem.Value;
                }
            }
            if (total >= 10)
            {
                foreach (KeyValuePair<string, int> elem in toWashLaundry)
                {
                    StockEquipement.Instance.Dirty[elem.Key] -= elem.Value;
                    StockEquipement.Instance.Washing[elem.Key] += elem.Value;
                }
                Thread t = new Thread(new ParameterizedThreadStart(Wash));
                t.Start(16000);
                t.Join();
                foreach (KeyValuePair<string, int> elem in toWashLaundry)
                {
                    StockEquipement.Instance.Washing[elem.Key] -= elem.Value;
                    StockEquipement.Instance.Clean[elem.Key] += elem.Value;

                }
                toWashLaundry.Clear();

            }
        }
        private static void checkDishes()
        {
            foreach (KeyValuePair<string, int> elem in StockEquipement.Instance.Dirty)
            {
                if (elem.Key != "towel" && elem.Key != "tablecloth")
                {
                    if (elem.Value > 5)
                    {
                        toWashDishes[elem.Key] += elem.Value;
                        StockEquipement.Instance.Dirty[elem.Key] -= elem.Value;
                        StockEquipement.Instance.Washing[elem.Key] += elem.Value;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Thread t = new Thread(new ParameterizedThreadStart(Wash));
            t.Start(10000);
            t.Join();

            foreach (KeyValuePair<string, int> elem in toWashDishes)
            {
                StockEquipement.Instance.Washing[elem.Key] -= elem.Value;
                StockEquipement.Instance.Clean[elem.Key] += elem.Value;
            }

            toWashDishes.Clear();
        }

        private static string ConvertBytesString(byte[] data)
        {
            return "true";
        }
        private static string ConvertStringBytes(string str)
        {
            return "true";
        }
    }
}
