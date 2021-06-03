using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class patientVisitswithnamesViewModel
    {
        public patientVisitswithnamesViewModel()
        {
            register_Medicines = new List<string>();
            critical_Datas = new List<string>();
        }
        public string FName { get; set; }

        public string sName { get; set; }
        public string tName { get; set; }
        public string FoName { get; set; }
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