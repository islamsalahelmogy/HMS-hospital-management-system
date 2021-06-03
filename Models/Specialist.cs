using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HMS_ITI.Models
{
    public partial class Specialist
    {
        [Display(Name = "رقم التخصص")]

        public int ID { get; set; }

        [StringLength(100, ErrorMessage ="ادخل التخصص بشكل صحيح")]
        [Display(Name = "اسم التخصص")]
        public string SpecialistName { get; set; }

        [StringLength(100, ErrorMessage = "ادخل التخصص بشكل صحيح")]
        [Display(Name = "اسم التخصص")]
        public string SpecialistNameEn { get; set; }

    }
}