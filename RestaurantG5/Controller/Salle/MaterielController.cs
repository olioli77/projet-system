using RestaurantG5.Controller.Cuisine;
using RestaurantG5.Model.Salle.Components;


namespace RestaurantG5.Controller.Salle
{
    public class MaterielController
    {
        public static bool defineAsDirty(string elem)
        {
            bool existDirty = StockEquipement.Instance.Dirty.TryGetValue(elem, out int eNumberDirty);
            bool existInUse = StockEquipement.Instance.InUse.TryGetValue(elem, out int eNumberInUse);
            if ((existDirty) && (existInUse) && (eNumberInUse > 0))
            {
                StockEquipement.Instance.InUse[elem] = eNumberInUse - 1;
                StockEquipement.Instance.Dirty[elem] = eNumberDirty + 1;
                KitchenCleanerController.checkCleaning();
                return true;
            }
            return false;
        }

        public static bool defineAsInUse(string elem)
        {
            bool existClean = StockEquipement.Instance.Clean.TryGetValue(elem, out int eNumberClean);
            bool existInUse = StockEquipement.Instance.InUse.TryGetValue(elem, out int eNumberInUse);
            if ((existClean) && (existInUse) && (eNumberClean > 0))
            {
                StockEquipement.Instance.InUse[elem] = eNumberInUse + 1;
                StockEquipement.Instance.Clean[elem] = eNumberClean - 1;
                return true;
            }
            return false;
        }

        public static bool defineAsClean(string elem)
        {
            bool existWashing = StockEquipement.Instance.Washing.TryGetValue(elem, out int eNumberWashing);
            bool existClean = StockEquipement.Instance.Clean.TryGetValue(elem, out int eNumberClean);
            if ((existClean) && (existWashing) && (eNumberWashing > 0))
            {
                StockEquipement.Instance.Clean[elem] = eNumberClean + 1;
                StockEquipement.Instance.Washing[elem] = eNumberWashing - 1;
                return true;
            }
            return false;
        }

        public static bool defineAsWashing(string elem)
        {
            bool existWashing = StockEquipement.Instance.Washing.TryGetValue(elem, out int eNumberWashing);
            bool existDirty = StockEquipement.Instance.Dirty.TryGetValue(elem, out int eNumberDirty);
            if ((existDirty) && (existWashing) && (eNumberDirty > 0))
            {
                StockEquipement.Instance.Washing[elem] = eNumberWashing + 1;
                StockEquipement.Instance.Dirty[elem] = eNumberDirty - 1;
                return true;
            }
            return false;
        }
    }
}
