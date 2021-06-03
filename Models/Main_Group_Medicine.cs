using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HMS_ITI.Models
{
    public partial class Main_Group_Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Main_Group_Medicine()
        {
            Part_Group_Medicines = new HashSet<Part_Group_Medicine>();
        }
        [Display(Name ="رقم الفئة")]
        public int ID { get; set; }

        [Display(Name = "اسم الفئة")]
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة")]
        [StringLength(100,ErrorMessage ="ادخل الاسم بشكل صحيح",MinimumLength =2)]
        public string NameArabic { get; set; }

        [Display(Name = "اسم الفئة")]
        [Required(ErrorMessage = "من فضلك ادخل اسم الفئة")]
        [StringLength( 100, ErrorMessage = "ادخل الاسم بشكل صحيح",MinimumLength =2)]
        public string NameEnglish { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part_Group_Medicine> Part_Group_Medicines { get; set; }
    }
}