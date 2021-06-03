using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Crit_Data")]
    public partial class Crit_Data
    {
        [Display(Name ="الرقم المسلسل")]
        public int ID { get; set; }

        public int? Id_Nozom { get; set; }

        public int? Id_Frequancy { get; set; }
        [Display(Name = "تاريخ البيانات الحرجة")]
        public DateTime Date { get; set; }
        [Display(Name ="بيانات حرجة")]
        public int Id_CriticalData { get; set; }

        [StringLength(500,ErrorMessage ="لقد تعديت الحد الاقصي لملاحظتك")]
        [Display(Name ="ملاحظات")]
        public string Notes { get; set; }
        public int? UserId { get; set; }

        public virtual Clinic_Register Clinic_Register { get; set; }

        public virtual Critical_Data Critical_Data { get; set; }
    }
}