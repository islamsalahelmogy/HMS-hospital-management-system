using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Recommendation_Adv
    {
        [Display(Name ="رقم التوصية")]
        public int ID { get; set; }

        public int? Id_Nozom { get; set; }

        public int? Id_Frequancy { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey("Recommendation_Advice")]
        [Display(Name ="التوصية الطبية")]
        public int Id_RecommendationAdvice { get; set; }
        [Required(ErrorMessage ="من فضلك ادخل ملاحظتك")]
        [StringLength(500,ErrorMessage ="ادخل ملاحظتك بشكل صحيح",MinimumLength =5)]
        [Display(Name ="ملاحظات")]
        public string Notes { get; set; }
        public int? UserId { get; set; }

        public virtual Clinic_Register Clinic_Register { get; set; }

        public virtual Recommendation_Advice Recommendation_Advice { get; set; }
    }
}