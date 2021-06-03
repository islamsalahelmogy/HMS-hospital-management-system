using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class MyProfileController : Controller
    {

        private HospitalContext db = new HospitalContext();
        public ActionResult MyProfile()
        {
            int userid = 0;
            if (Session["UserId"] != null)
            {
                userid = (int)Session["UserId"];
            }

            var authorize = db.Registrations.Where(w => w.ID == userid).FirstOrDefault();
            if (authorize != null)
            {
                var query = (from e in db.Employees
                             join r in db.Registrations on e.ID equals r.ID
                             join d in db.Departments on e.Department_ID equals d.ID
                             join ro in db.Roles on r.RoleId equals ro.ID
                             where e.ID == userid
                             select new ApproveRegistrationViewModel
                             {
                                 FullName = e.FirstName + " " + e.SecondName + " " + e.ThirdName + " " + e.FourthName,
                                 UserName = r.UserName,
                                 Password = r.Password,
                                 DepartmentName = d.DepartmentName,
                                 RoleName = ro.RoleNameAr,
                                 ID = r.ID,
                                 Image=e.Image
                             }).FirstOrDefault();

                return View(query);
            }
            return RedirectToAction("Index", "RequestRegisterClinics");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            int registerid = 0;
            if (Session["UserId"] != null)
            {
                registerid = (int)Session["ID"];
                return View(db.Registrations.Where(w => w.ID == registerid).FirstOrDefault());
            }
            return RedirectToAction("Index", "RequestRegisterClinics");
        }
        [HttpPost]
        public ActionResult ChangePassword(Registration reg)
        {
            if (ModelState.IsValid)
            {
                int id = reg.ID;
                Registration update = db.Registrations.Find(id);
                update.UserName = reg.UserName;
                update.Password = reg.Password;
                db.SaveChanges();
                return View();
            }
            return View(reg);
        }
    }

}
