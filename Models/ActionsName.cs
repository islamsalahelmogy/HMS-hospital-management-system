using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models
{
    public class ActionsName
    {
        public ActionsName()
        {
            this.Role_ActionName = new HashSet<Role_ActionName>();
        }
        [Display(Name ="رقم العرض")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required(ErrorMessage = "عفوا من فضلك ادخل الاسم")]
        [Index(IsUnique = true)]
        [Display(Name = "اسم الصفحة ")]
        [StringLength(100, ErrorMessage = "من فضللك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        public string ActionName { get; set; }
        [Required(ErrorMessage = "عفوا من فضلك ادخل اسم العرض ")]
        [StringLength(100, ErrorMessage = "من فضللك ادخل الاسم بشكل صحيح", MinimumLength = 2)]
        [Index(IsUnique = true)]
        [Display(Name = "الاسم المعروض ")]
        public string ShowName { get; set; }

        public virtual ICollection<Role_ActionName> Role_ActionName { get; set; }
    }
}