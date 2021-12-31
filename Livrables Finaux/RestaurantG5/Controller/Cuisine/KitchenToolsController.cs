using RestaurantG5.Model.Cuisine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantG5.Model.Salle.Components;

namespace RestaurantG5.Controller.Cuisine
{
    public class KitchenToolsController
    {
        public void senddirtytools(string kitchenware, int quantity)
        {
               StockEquipement.Instance.Dirty[kitchenware] += quantity;
            StockEquipement.Instance.Clean[kitchenware] -= quantity;
        }

        public void SetInUseTool(string kitchenware)
        {
            StockKitchenWare.Instance.Stock[kitchenware].WaitOne();
        }

        public void ReceiveCleanTools(string kitchenware, int quantity)
        {
            StockEquipement.Instance.Dirty[kitchenware] -= quantity;
            StockEquipement.Instance.Clean[kitchenware] += quantity;
        }

        public bool VerifyStock(string kitchenware, int quantity)
        {
            int stockQuantity = StockEquipement.Instance.Clean[kitchenware];
            return (stockQuantity >= quantity && quantity > 0) ? true : false;
        }
    }
}
