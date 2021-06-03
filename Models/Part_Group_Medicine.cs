using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS_ITI.Models
{
    public partial class Part_Group_Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part_Group_Medicine()
        {
            Medicines = new HashSet<Medicine>();
        }
        [Display(Name ="رقم الفئة الفرعية")]
        public int ID { get; set; }

        [Display(Name = " الفئة الفرعية ")]
        [Required(ErrorMessage = "من فضلك ادخل الفئة الفرعية")]
        [StringLength(100, ErrorMessage = "ادخل اسم الفئة الفرعية بشكل صحيح",MinimumLength =2)]
        public string NameArabic { get; set; }

        [StringLength( 100, ErrorMessage = "ادخل اسم الفئة الفرعية بشكل صحيح",MinimumLength =2)]
        [Required(ErrorMessage = "من فضلك ادخل الفئة الفرعية")]
        [Display(Name = " الفئة الفرعية ")]

        public string NameEnglish { get; set; }
        [Display(Name = "الفئة")]
        [ForeignKey("Main_Group_Medicine")]
        public int? MainGroupId { get; set; }

        public virtual Main_Group_Medicine Main_Group_Medicine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}