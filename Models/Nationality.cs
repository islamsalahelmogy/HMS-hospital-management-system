using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS_ITI.Models
{
    public partial class Nationality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nationality()
        {
            Patients = new HashSet<Patient>();
        }
        [Display(Name ="رقم الجنسية")]
        public int ID { get; set; }
        [Display(Name = "الجنسية")]

        [Required(ErrorMessage ="من فضلك ادخل جنسيتك")]
        [StringLength(100, ErrorMessage = "ادخل جنسيتك بشكل صحيح",MinimumLength =2)]
        public string Nationa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}