using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Career")]
    public partial class Career
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Career()
        {
            Employees = new HashSet<Employee>();
        }
        [Display(Name = "الرقم الوظيفي")]
        public int ID { get; set; }

        [StringLength(40, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "من فضلك ادخل اسم المهنة")]
        [Display(Name = "المهنة")]
        public string CareerType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}