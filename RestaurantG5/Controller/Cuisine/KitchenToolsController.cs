using RestaurantG5.Model.Cuisine;

namespace RestaurantG5.Controller.Cuisine
{
    public class KitchenToolsController
    {
        public void senddirtytools(string kitchenware, int quantity)
        {
            //    stockkitchenware.instance.dirty[kitchenware] += quantity;
            //    stockkitchenware.instance.clean[kitchenware] -= quantity;
        }

        public void SetInUseTool(string kitchenware)
        {
            StockKitchenWare.Instance.Stock[kitchenware].WaitOne();
        }

        public void ReceiveCleanTools(string kitchenware, int quantity)
        {
            //StockKitchenware.Instance.Dirty[kitchenware] -= quantity;
            //StockKitchenware.Instance.Clean[kitchenware] += quantity;
        }

        //public bool VerifyStock(string kitchenware, int quantity)
        //{
        //    int stockQuantity = StockKitchenware.Instance.Clean[kitchenware];
        //    return (stockQuantity >= quantity && quantity > 0) ? true : false;
        //}
    }
}
