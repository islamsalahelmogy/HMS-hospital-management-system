using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class PatientViewmodel
    {
        [Display(Name = "رقم المريض")]

        public Int64 ID_Nozom { get; set; }
        [Display(Name = "اسم المريض")]

        public string PatientName { get; set; }
    }
}