using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HMS_ITI.Models
{
    public partial class Number_Of_Take_Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Number_Of_Take_Medicine()
        {
            Register_Medicines = new HashSet<Register_Medicine>();
        }
        [Display(Name ="رقم الدواء")]
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "ادخل عدد الدواء بشكل صحيح")]
        public string Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Register_Medicine> Register_Medicines { get; set; }
    }
}