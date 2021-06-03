using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models
{
    public class Role
    {
        public Role()
        {
            this.Registration = new HashSet<Registration>();
            this.Role_ActionName = new HashSet<Role_ActionName>();
        }
        [Display(Name = "رقم الصلاحية ")]

        public int ID { get; set; }
        [Required(ErrorMessage="عفوا من فضلك ادخل الاسم")]
        [Index(IsUnique = true)]
        [StringLength(30, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "اسم الصلاحية  ")]
        public string RoleNameAr { get; set; }
        [Required(ErrorMessage = "عفوا من فضلك ادخل الاسم")]
        [StringLength(30, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Display(Name = "اسم الصلاحية  ")]
        public string RoleNameEn { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<Role_ActionName> Role_ActionName {get;set;}
    }
}