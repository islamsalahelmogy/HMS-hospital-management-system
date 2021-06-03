using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Diagnosis
    {
        [Display(Name ="رقم التشخيص")]
        public int ID { get; set; }

        public int? Id_Nozom { get; set; }

        public int? Id_Frequancy { get; set; }

        public DateTime Date { get; set; }

        [StringLength(1000, ErrorMessage = "لقد تخطيت الحد الاقصي لتشخيصك",MinimumLength =10)]
        [Display(Name ="التشخيص")]
        [Required(ErrorMessage ="من فضلك ادخل تشخيص المريض")]
        public string _Diagnosis { get; set; }
        public int? UserId { get; set; }

        public virtual Clinic_Register Clinic_Register { get; set; }
    }
}