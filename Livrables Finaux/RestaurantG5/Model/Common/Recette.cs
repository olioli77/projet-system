using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantG5.Model.Common
{
    [Table("Recette")]
        public partial class Recette
        {
            [Key]
            public long id_recette { get; set; }

            [Column(TypeName = "text")]
            public string liste_etapes_recette { get; set; }

            [StringLength(50)]
            public string nom_recette { get; set; }

            [StringLength(50)]
            public string categorie { get; set; }
        }
   
}
