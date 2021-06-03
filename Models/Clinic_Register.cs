using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    [Table("Clinic_Register")]
    public partial class Clinic_Register
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clinic_Register()
        {
            Crit_Datas = new HashSet<Crit_Data>();
            Diagnosis = new HashSet<Diagnosis>();
            Recommendation_Advs = new HashSet<Recommendation_Adv>();
        }
        [Display(Name = "رقم تسجيل العياده")]
        public int ID { get; set; }

        public int ID_Frequancy { get; set; }
        [Index("cln", 1, IsUnique = true)]
        public int Id_patient { get; set; }
        [Index("cln", 2, IsUnique = true)]
        [Display(Name = "وقت الوصول")]
        public DateTime? DateIncoming { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "وقت المغادرة")]
        public DateTime? DateLeaving { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "وقت الوصول")]

        public DateTime? TimeComing { get; set; }

        [Display(Name ="العيادة")]
        [ForeignKey("Clinic_Type")]
        public int? ClinicTypeId { get; set; }
        [Display(Name ="القسم")]
        [Index("cln", 3, IsUnique = true)]
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public int? UserId { get; set; }
        [Display(Name ="رقم")]
        public int? counterNumber { get; set; }

        public virtual Clinic_Type Clinic_Type { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crit_Data> Crit_Datas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosis> Diagnosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation_Adv> Recommendation_Advs { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

    }
}