using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS_ITI.Models;

namespace HMS_ITI.Models
{
    public class RequestRegisterClinic
    {
        public RequestRegisterClinic()
        {
        }
        [Display(Name ="رقم تسجيل العيادة")]
        [Key]
        public long ID{ get; set; }

        [Required(ErrorMessage = "اختار الاسم الاول")]
        [StringLength(15,ErrorMessage ="ادخل الاسم الاول بشكل صحيح")]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [Display(Name ="الاسم الثاني")]
        [Required(ErrorMessage = "ادخل الاسم الثاني")]
        [StringLength(15, ErrorMessage = "ادخل الاسم الثاني بشكل صحيح")]
        public string SecondName { get; set; }

        [Display(Name ="الاسم الثالث")]
        [Required(ErrorMessage = "ادخل الاسم الثالث")]
        [StringLength(15, ErrorMessage = "ادخل الاسم الثالث بشكل صحيح")]
        public string ThirdName { get; set; }

        [Display(Name ="الاسم الرابع")]
        [Required(ErrorMessage = "ادخل الاسم الرايع")]
        [StringLength(15, ErrorMessage = "ادخل الاسم الرابع بشكل صحيح")]
        public string FourthName { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [Required(ErrorMessage = "ادخل تاريخ الميلاد")]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Display(Name ="تاريخ التسجيل")]
        [Required(ErrorMessage = "تاريخ التسجيل ادخل ")]
        [Column(TypeName = "date")]
        public DateTime RegisteredDate { get; set; }

        [Display(Name ="رقم التلفون")]
        [Required(ErrorMessage = "ادخل رقم التليفون")]
        [StringLength(11, ErrorMessage = "ادخل رقم الهاتف بشكل صحيح")]
        public string Phone { get; set; }

        [Display(Name ="الرقم القومي")]
        [Required(ErrorMessage = "ادخل رقم القومي")]
        [StringLength(14, ErrorMessage = "ادخل الرقم القومي بشكل صحيح")]
        public string SSN { get; set; }

        [Required]
        public int Department_Id { get; set; }

        public int Sex_id { get; set; }
        public bool? Status { get; internal set; }
        //public int National_id { get; set; }
    }
}