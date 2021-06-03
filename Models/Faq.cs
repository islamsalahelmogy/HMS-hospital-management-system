using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public class Faq
    {
        [Display(Name = "الرقم المسلسل")]
        public int Id { get; set; }
        [Required(ErrorMessage = "اختار صورة من فضلك  ")]
        [Display(Name = "الصورة")]
        public string Image { get; set; }
        [Required(ErrorMessage = "ادخل حقل التفاصيل من  فضلك ")]
        [StringLength(200,ErrorMessage ="ادخل وصفك بشكل صحيح",MinimumLength =5)]
        [Display(Name = "الوصف")]
        public string Description { get; set; }
        [Display(Name = "تاريخ النشر")]
        [Required(ErrorMessage = "ادخل حقل تاريخ النشر من  فضلك ")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "عنوان الخبر")]
        [Required(ErrorMessage = "ادخل حقل عنوان الخبر من  فضلك ")]
        public string Title { get; set; }

    }
}