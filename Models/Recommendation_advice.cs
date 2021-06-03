using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Recommendation_Advice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recommendation_Advice()
        {
            Recommendation_Advs = new HashSet<Recommendation_Adv>();
        }
        [Display(Name ="رقم التوصية الطبية")]
        public int ID { get; set; }
        [Display(Name = "التوصية الطبية")]
        [Required(ErrorMessage ="من فضلك ادخل التوصية الطبية")]
        [StringLength(500,ErrorMessage ="ادخل التوصية الطبية بشكل صحيح",MinimumLength =5)]
        public string Recommendation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation_Adv> Recommendation_Advs { get; set; }
    }
}