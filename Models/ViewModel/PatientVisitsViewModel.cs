using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class PatientVisitsViewModel
    {
        public PatientVisitsViewModel()
        {
            register_Medicines = new List<string>();
            critical_Datas = new List<string>();
        }
        [Display(Name = " رقم النظم")]
        public int ID_Nozom { get; set; }
        [Display(Name = "التاريخ")]

        public DateTime date { get; set; }
        [Display(Name = "اسم القسم")]

        public string DepartmentName { get; set; }
        [Display(Name = "الدواء")]

        public List<string> register_Medicines { get; set; }
        [Display(Name = "التشخيص")]

        public string diagnoses { get; set; }
        [Display(Name = "بيانات حرجة")]

        public List<string> critical_Datas { get; set; }

    }
}