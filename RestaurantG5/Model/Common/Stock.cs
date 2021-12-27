using RestaurantG5.Model.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantG5.Model.Common
{
    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public long id_stock { get; set; }

        public TimeSpan? date_expire_Ingredient { get; set; }

        public long? quantité_Stock { get; set; }

        public long? id_Ingredient { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
