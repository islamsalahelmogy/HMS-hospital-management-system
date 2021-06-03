using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Systolic_Blood_Pressure
    {
        [Display(Name ="رقم ضغط الدم")]
        public int ID { get; set; }

        public int? Id_ClinicRegister { get; set; }

        public int? Id_Frequancy { get; set; }
        [Display(Name = "تاريخ ضغط الدم")]

        public DateTime Date { get; set; }

        public DateTime DateOf_TakeTheStatment { get; set; }

        public DateTime TimeOf_TakeTheStatment { get; set; }

        [Column("SystolicBloodPressure")]
        public byte? SystolicBloodPressure1 { get; set; }

        public byte? Pulse { get; set; }

        public byte? InterstitialBloodPressure { get; set; }

        public double? Temperature { get; set; }

        public byte? RespiratoryRate { get; set; }
    }
}