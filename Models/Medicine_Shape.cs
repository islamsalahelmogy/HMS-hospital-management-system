using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Medicine_Shape
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine_Shape()
        {
            Medicines = new HashSet<Medicine>();
        }
        [Display(Name ="رقم نوع الدواء")]
        public int ID { get; set; }

        [StringLength( 100, ErrorMessage = "ادخل اسم نوع الدواء بشكل صحيح",MinimumLength =2)]
        [Display(Name = "نوع الدواء ")]
        [Required(ErrorMessage ="من فضلك ادخل نوع الدواء") ]
        public string Name_Arabic { get; set; }

        [StringLength( 100, ErrorMessage = "ادخل اسم نوع الدواء بشكل صحيح",MinimumLength =2)]
        [Display(Name = "نوع الدواء ")]
        [Required(ErrorMessage = "من فضلك ادخل نوع الدواء")]

        public string Name_English { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}