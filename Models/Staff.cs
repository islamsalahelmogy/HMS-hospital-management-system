using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HMS_ITI.Models
{
    public class Staff
    {
        [Display(Name ="رقم طاقم العمل")]
        public int Id { get; set; }
        [Display(Name ="صورة ")]
        [Required(ErrorMessage = "اختاار صورة ")]
        public string Image { get; set; }
        [Display(Name ="السيرة الذاتية")]
        [Required(ErrorMessage = "ادخل حقل السيرة الذاتية ")]
        [StringLength(500,ErrorMessage ="ادخل السيرة الذاتية بشكل صحيح",MinimumLength =20)]
        public string Bio { get; set; }
        [Display(Name ="الوظيفة")]
        [Required(ErrorMessage = "ادخل حقل الوظيفة ")]
        [StringLength( 50, ErrorMessage = "ادخل الوظيفة بشكل صحيح",MinimumLength =2)]
        public string Position { get; set; }
        [Display(Name ="تاريخ التعيين")]
        [Required(ErrorMessage = "ادخل حقل تاريخ تسجيل الوظيفة ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "ادخل حقل الاسم ")]
        [Display(Name = "اسم الطبيب ")]
        [StringLength( 100, ErrorMessage = "ادخل الاسم بشكل صحيح",MinimumLength =2)]
        public string FullName { get; set; }
    }
}