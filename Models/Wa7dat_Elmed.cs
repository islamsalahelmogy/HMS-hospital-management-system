using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HMS_ITI.Models
{
    public partial class Wa7dat_Elmed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wa7dat_Elmed()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string NameAr { get; set; }

        [StringLength(50)]
        public string NameEn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}