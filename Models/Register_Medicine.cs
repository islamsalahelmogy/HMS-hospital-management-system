using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Register_Medicine
    {
        [Display(Name ="رقم التسجيل")]
        public int ID { get; set; }

        public long? Id_Nozom { get; set; }

        public int? Id_Frequancy { get; set; }
        [Display(Name = "تاريخ تسجيل الدواء")]

        public DateTime Date { get; set; }
        [Display(Name = "الدواء")]
        public int? ID_Medicin { get; set; }

        public int? Dose { get; set; }

        [ForeignKey("Number_Of_Take_Medicine")]
        [Display(Name = "عدد المرات")]
        [Required(ErrorMessage ="من فضلك حدد عدد مرات تناول الدواء")]
        public int? IdNumberOfTakeMedicin { get; set; }
        [ForeignKey("Time_Take_Medicine1")]
        [Display(Name = "الوقت")]
        [Required(ErrorMessage = "من فضلك حدد موعد تناول الدواء")]
        public int? IdTimeTakeMedicin1 { get; set; }
        [ForeignKey("Time_Take_Medicine2")]
        [Required(ErrorMessage = "من فضلك حدد موعد تناول الدواء")]
        [Display(Name = "الوقت")]
        public int? IdTimeTakeMedicin2 { get; set; }

        [StringLength(200,ErrorMessage ="ادخل وصف الدواء بشكل صحيح")]
        public string DescriptionToTakeMedicin { get; set; }

        public int? User_Id { get; set; }

        public virtual Number_Of_Take_Medicine Number_Of_Take_Medicine { get; set; }

        public virtual Time_Take_Medicine1 Time_Take_Medicine1 { get; set; }

        public virtual Time_Take_Medicine2 Time_Take_Medicine2 { get; set; }
    }
}