using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Medicine
    {
        [Display(Name = "رقم الدواء")]
        public int ID { get; set; }
        [Display(Name ="الرقم المسلسل")]
        [Required(ErrorMessage = "من فضلك ادخل رقم الدواء")]
        public int IDMedicin { get; set; }
        [Display(Name = "الفئة الفرعية")]
        [ForeignKey("Part_Group_Medicine")]
        public int? PartGroupId { get; set; }
        [Display(Name = "نوع الدواء")]
        [ForeignKey("Medicine_Shape")]
        public int? ShapeId { get; set; }
        [Display(Name = "شركة التصنيع")]
        [ForeignKey("Medicine_Company")]
        public int? CompanyId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الدواء")]
        [Display(Name = "الاسم ")]
        [StringLength(100,ErrorMessage ="ادخل اسم الدواء بشكل صحيح",MinimumLength =2)]
        public string MedNameArabic { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم الدواء")]
        [Display(Name ="الاسم ")]
        [StringLength(100, ErrorMessage = "ادخل اسم الدواء بشكل صحيح",MinimumLength =2)]
        public string MedNameEnglish { get; set; }
        [Required()]
        public DateTime? DateMedicinRegister { get; set; }
        [Display(Name = "الكمية")]
        [Required(ErrorMessage = "من فضلك ادخل الكمية")]
        public int? AllowedCurrent { get; set; }
      
        public virtual Medicine_Company Medicine_Company { get; set; }

        public virtual Medicine_Shape Medicine_Shape { get; set; }

        public virtual Part_Group_Medicine Part_Group_Medicine { get; set; }
    }
}