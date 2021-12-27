using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantG5.Model.Common
{
    [Table("Etape")]
    public partial class Etape
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Etape()
        {
            compose = new HashSet<compose>();
        }

        [Key]
        public long id_etape { get; set; }

        [StringLength(50)]
        public string nom_etape { get; set; }

        public long? temps_etape { get; set; }

        public int? sync_etape { get; set; }

        public long? id_Ustensile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compose> compose { get; set; }

        public virtual Ustensile Ustensile { get; set; }
    }
}
