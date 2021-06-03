using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models
{
    public class Role_ActionName
    {
        [Display(Name ="رقم القاعدة")]
        public int ID { get; set; }
        [Display(Name ="الصلاحية")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [Display(Name ="العرض")]
        [ForeignKey("ActionsName")]
        public int ActionNameId { get; set; }

        public virtual ActionsName ActionsName { get; set; }
        public virtual Role Role { get; set; }
    }
}