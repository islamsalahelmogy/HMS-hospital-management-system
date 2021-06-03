using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS_ITI.Models
{
    public partial class Sex_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sex_Type()
        {
            Patients = new HashSet<Patient>();
        }
        [Display(Name = "رقم النوع")]

        public int ID { get; set; }

        [Display(Name = " النوع")]
        [StringLength(5,ErrorMessage ="من فضلك ادخل النوع")]
        public string TypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }

       }
}