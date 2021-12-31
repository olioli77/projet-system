using System.ComponentModel.DataAnnotations;

namespace RestaurantG5.Model.Common
{
    public partial class compose
    {
        [Key]
        public long id_compose { get; set; }

        public long id_etape { get; set; }

        public long id_Ingredient { get; set; }

        public virtual Etape Etape { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
