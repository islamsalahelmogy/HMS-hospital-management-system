using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS_ITI.Models
{
    public partial class Religion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Religion()
        {
            Patients = new HashSet<Patient>();
        }
        [Display(Name = "رقم الدياننة")]
        public int ID { get; set; }
        [Display(Name = "الديانة")]
        [Column("Religion")]
        [StringLength(10,ErrorMessage ="ادخل الديانة بشكل صحيح")]
        public string _Religion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}