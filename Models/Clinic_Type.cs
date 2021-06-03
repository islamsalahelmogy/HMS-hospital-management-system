using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Clinic_Type")]

    public partial class Clinic_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clinic_Type()
        {
            Clinic_Registers = new HashSet<Clinic_Register>();
            Employees = new HashSet<Employee>();
        }
        [Display(Name = "رقم نوع العياده")]

        public int ID { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل نوع العيادة")]

        [StringLength(60, ErrorMessage = " من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Index(IsUnique =true)]
        [Display(Name = "نوع العيادة")]

        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clinic_Register> Clinic_Registers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}