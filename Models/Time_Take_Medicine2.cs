using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HMS_ITI.Models
{
    public partial class Time_Take_Medicine2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Time_Take_Medicine2()
        {
            RegisterMedicins = new HashSet<Register_Medicine>();
        }
        [Display(Name = "رقم اخد الدواء")]
        public int ID { get; set; }

        [Display(Name = "وقت اخد الدواء")]
        [StringLength(50, ErrorMessage = "ادخل الوقت بشكل صحيح")]
        public string Time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Register_Medicine> RegisterMedicins { get; set; }
    }
}