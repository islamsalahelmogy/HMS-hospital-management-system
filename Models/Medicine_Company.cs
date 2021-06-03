using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Medicine_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine_Company()
        {
            Medicines = new HashSet<Medicine>();
        }
        [Display(Name ="رقم الشركة")]
        public int ID { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم الشركة")]
        [StringLength(100,ErrorMessage ="ادخل اسم الشركة بشكل صحيح",MinimumLength =2)]
        [Display(Name = "شركة التصنيع")]

        public string Name_Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}