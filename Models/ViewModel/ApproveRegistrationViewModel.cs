using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public class ApproveRegistrationViewModel
    {
        [Display(Name ="رقم المستخدم")]
        public int ID { get; set; }
        [Display(Name ="الاسم بالكامل")]
        public string FullName { get; set; }
        [Display(Name ="اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name ="كلمة المرور")]
        public string Password { get; set; }
        [Display(Name ="القسم")]
        public string DepartmentName { get; set; }
        [Display(Name ="الصلاحية")]
        public string RoleName { get; set; }
        [Display(Name ="الصورة")]
        public string Image { get; set; }
    }
}
