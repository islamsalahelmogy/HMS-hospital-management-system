using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table ("Employee")]
    public partial class Employee
    {
        [Display(Name = "الرقم الموظف")]
        public int ID { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم الاول")]
        [StringLength(15, ErrorMessage = " من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم الثاني")]
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "الاسم الثاني")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم الثالث")]
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "الاسم الثالث")]
        public string ThirdName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم الرابع")]
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "الاسم الرابع")]
        public string FourthName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الرقم القومي")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "من فضلك ادخل الرقم القومي بشكل صحيح")]
        [Index(IsUnique =true)]
        [Display(Name = "الرقم القومي")]
        [RegularExpression("([0-9]+)", ErrorMessage = "من فضلك ادخل ارقام فقط")]

        public string SSN { get; set; }

        [Display(Name = "اضافة صورة")]

        public string Image { get; set; }
        [Required(ErrorMessage = "عفوا هذا الحقل مطلوب")]
        [Display(Name = "المهنة")]
        [ForeignKey("Career")]
        public int Career_ID { get; set; }
        [Required(ErrorMessage = "عفوا هذا الحقل مطلوب")]
        [Display(Name = "القسم")]
        [ForeignKey("Department")]
        public int Department_ID { get; set; }
        [Display(Name = "اسم المستخدم")]
        [NotMapped]
        public string UserName { get; set; }
        [Display(Name = "كلمة المرور")]
        [NotMapped]
        public string Password { get; set; }
        [Display(Name = "الصلاحية")]
        [NotMapped]
        [Required(ErrorMessage = "عفوا هذا الحقل مطلوب")]
        public int RoleId { get; set; }

        public virtual Career Career { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual Department Department { get; set; }
    }
}