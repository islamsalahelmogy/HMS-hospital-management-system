using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ITI.Models
{
    public partial class Patient
    {
        [Key]
        [Display(Name ="رقم المريض")]
        public long ID_Nozom { get; set; }
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح ", MinimumLength = 2)]
        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "الاسم الاول")]

        public string FirstName { get; set; }
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح ", MinimumLength = 2)]
        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "الاسم الثاني")]

        public string SecondName { get; set; }
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح ", MinimumLength = 2)]
        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "الاسم الثالث")]

        public string ThirdName { get; set; }
        [StringLength(15, ErrorMessage = "من فضلك ادخل الاسم بشكل صحيح ", MinimumLength = 2)]
        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "الاسم الرابع")]

        public string FourthName { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(11, ErrorMessage = "من فضلك ادخل الرقم بشكل صحيح ", MinimumLength = 2)]
        [Required(ErrorMessage = "من فضلك ادخل رقم الهاتف")]
        [Display(Name = "رقم الهاتف")]
        [RegularExpression("([0-9]+)", ErrorMessage = "من فضلك ادخل ارقام فقط")]
        public string Phone { get; set; }

        [StringLength(14, ErrorMessage = "من فضلك ادخل الرقم القومي بشكل صحيح ", MinimumLength = 14)]
        [Required(ErrorMessage = "من فضلك ادخل الرقم القومي")]
        [Index(IsUnique = true)]
        [Display(Name = "الرقم القومي")]
        [RegularExpression("([0-9]+)", ErrorMessage = "من فضلك ادخل ارقام فقط")]
        public string SSN { get; set; }
        [ForeignKey("Sex_Type")]
        public int? IdType { get; set; }
        [ForeignKey("Religion")]
        public int? IdReligion { get; set; }

        public bool? Status { get; set; }
        [ForeignKey("Nationality")]
        public int? IdNationalty { get; set; }
        [NotMapped]
        public string PatientName { get; set; }
        [NotMapped]
        public int? Age { get; set; }
        [NotMapped]
        public int? Flag { get; set; }
        public virtual Nationality Nationality { get; set; }

        public virtual Religion Religion { get; set; }

        public virtual Sex_Type Sex_Type { get; set; }
        public virtual Clinic_Register Clinic_Register { get; set; }

    }
}