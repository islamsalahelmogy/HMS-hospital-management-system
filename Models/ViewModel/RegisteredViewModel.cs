using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class RegisteredViewModel
    {
        [Display(Name = "رقم النظم")]

        public int? ID_Nozom { get; set; }
        [Display(Name ="الاسم")]
        public string FullName { get; set; }
        [Display(Name = "موعد الوصول")]

        public DateTime? TimeComing { get; set; }
        [Display(Name = "دور دخول العيادة")]
        public int? counterNumber { get; set; }
        [Display(Name = "تردد المريض")]

        public int? ID_Frequancy { get; set; }
        [Display(Name = "القسم")]

        public string DepartmentName { get; set; }
    }
}