using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HMS_ITI.Models
{
    public class Images
    {
        [Display(Name = "الرقم المسلسل")]
        public int ID { get; set; }

        public int? Id_ClinicRegister { get; set; }

        public int? Id_Frequancy { get; set; }
        [Display(Name = "تاريخ الصورة")]

        public DateTime Date { get; set; }
        [Display(Name = "الصورة الاولي")]

        public string Image1 { get; set; }
        [Display(Name = "الصورة الثانية")]

        public string Image2 { get; set; }
        [Display(Name = "الصورة الثالثة")]

        public string Image3 { get; set; }
        [Display(Name = "الصورة الرابعة")]

        public string Image4 { get; set; }
    }
}