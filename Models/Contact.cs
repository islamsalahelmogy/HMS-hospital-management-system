using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public class Contact
    {
        [Display(Name = "الرقم المسلسل")]

        public int ID { get; set; }
        [Required(ErrorMessage ="من فضلك ادخل الاسم")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Required(ErrorMessage ="من فضلك ادخل البريد الالكتروني")]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل الموضوع")]
        [Display(Name = "الموضوع")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل الرسالة")]
        [Display(Name = "المحتوى")]
        public string Message { get; set; }
    }
}