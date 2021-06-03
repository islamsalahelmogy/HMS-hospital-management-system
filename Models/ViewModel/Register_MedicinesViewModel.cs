using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class Register_MedicinesViewModel
    {
        [Display(Name ="الباركود")]
        public int medcinid { get; set; }
        [Display(Name = "أسم الدواء")]
        public string medcinname { get; set; }
        [Display(Name = "عدد المرات")]
        public string numtake { get; set; }
        [Display(Name = "الوقت")]
        public string timetake1 { get; set; }
        [Display(Name = "الوقت")]
        public string timetake2 { get; set; }
    }
}