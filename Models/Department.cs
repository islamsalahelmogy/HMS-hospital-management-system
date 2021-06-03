using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Clinic_Registers = new HashSet<Clinic_Register>();
            Employees = new HashSet<Employee>();
        }
        [Display(Name = "الرقم التعريفي")]
        public int ID { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم القسم")]
        [StringLength(100, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح ", MinimumLength = 2)]
        [Index(IsUnique = true)]
        [Display(Name = "القسم")]
        public string DepartmentName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clinic_Register> Clinic_Registers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}