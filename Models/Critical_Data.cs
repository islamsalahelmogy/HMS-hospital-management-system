using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Critical_Data")]
    public partial class Critical_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Critical_Data()
        {
            Crit_Datas = new HashSet<Crit_Data>();
        }

        [Display(Name = "الرقم التعريفي")]
        public int ID { get; set; }
        [StringLength(500,ErrorMessage ="لقد تخطيت الحد الاقصي لوصفك")]
        [Display(Name ="بيانات حرجة")]
        public string Critic_Data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crit_Data> Crit_Datas { get; set; }
    }
}