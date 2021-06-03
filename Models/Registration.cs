using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models
{
    public class Registration
    {
        public Registration()
        {
        }
        [ForeignKey("Employee")]
        [Display(Name ="رقم تسجيل الموضف")]
        public int ID { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name ="كلمة المرور")]
        public string Password { get; set; }
        [ForeignKey("Role")]
        [Display(Name = "الصلاحية")]
        public int RoleId { get; set; }
        public int? IdType { get; set; }
        public Nullable<bool> AccountActivation { get; set; }

        public virtual Role Role { get; set; }
        public virtual Employee Employee { get; set; }
    }
}