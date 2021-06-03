using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class LoginController : Controller
    {
        private HospitalContext db = new HospitalContext();
        [HttpPost]
        public ActionResult Login(string Username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.Registrations.Where(reg => reg.UserName == Username && reg.Password == password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return RedirectToAction("Index", "RequestRegisterClinics");
                }
                else
                {
                    var employee = db.Employees.Where(e => e.ID == user.ID).FirstOrDefault();
                    Session["UserName"] = Settings.UserName = user.UserName;
                    Session["RoleId"] = Settings.RoleId = user.RoleId;
                    Session["DepartmentID"] = employee.Department_ID;
                    Session["UserId"] = Settings.UserId = user.ID;
                    return RedirectToAction("ClinicRegister", "ClinicRegister");
                }
            }
            return RedirectToAction("Index", "RequestRegisterClinics");
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "RequestRegisterClinics");
        }

        [HttpGet]
        public ActionResult ApproveRegistration(int? id)
        {
            if (Settings.check("LoginController_ApproveRegistration") && Session["UserId"] != null)
            {
                if (id == null)
                {
                    var query = (from e in db.Employees
                                 join r in db.Registrations on e.ID equals r.ID
                                 join d in db.Departments on e.Department_ID equals d.ID
                                 join ro in db.Roles on r.RoleId equals ro.ID
                                 where r.AccountActivation == false
                                 select new ApproveRegistrationViewModel
                                 {
                                     FullName = e.FirstName + " " + e.SecondName + " " + e.ThirdName + " " + e.FourthName,
                                     UserName = r.UserName,
                                     Password = r.Password,
                                     DepartmentName = d.DepartmentName,
                                     RoleName = ro.RoleNameAr,
                                     ID = r.ID
                                 }).ToList();
                    return View(query);
                }
                else
                {
                    Registration re = db.Registrations.Find(id);
                    re.AccountActivation = true;
                    db.SaveChanges();
                    var query = (from e in db.Employees
                                 join r in db.Registrations on e.ID equals r.ID
                                 join d in db.Departments on e.Department_ID equals d.ID
                                 join ro in db.Roles on r.RoleId equals ro.ID
                                 where r.AccountActivation == false
                                 select new ApproveRegistrationViewModel
                                 {
                                     FullName = e.FirstName + " " + e.SecondName + " " + e.ThirdName + " " + e.FourthName,
                                     UserName = r.UserName,
                                     Password = r.Password,
                                     DepartmentName = d.DepartmentName,
                                     RoleName = ro.RoleNameAr,
                                     ID = r.ID
                                 }).ToList();

                    return View(query);
                }
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        public ActionResult DisableAccount(int? id)
        {
            if (Settings.check("LoginController_DisableAccount") && Session["UserId"] != null)
            {
                if (id == null)
                {
                    var query = (from e in db.Employees
                                 join r in db.Registrations on e.ID equals r.ID
                                 join d in db.Departments on e.Department_ID equals d.ID
                                 join ro in db.Roles on r.RoleId equals ro.ID
                                 where r.AccountActivation == true
                                 select new ApproveRegistrationViewModel
                                 {
                                     FullName = e.FirstName + " " + e.SecondName + " " + e.ThirdName + " " + e.FourthName,
                                     UserName = r.UserName,
                                     Password = r.Password,
                                     DepartmentName = d.DepartmentName,
                                     RoleName = ro.RoleNameAr,
                                     ID = r.ID
                                 }).ToList();
                    return View(query);
                }
                else
                {
                    Registration re = db.Registrations.Find(id);
                    re.AccountActivation = false;
                    db.SaveChanges();
                    var query = (from e in db.Employees
                                 join r in db.Registrations on e.ID equals r.ID
                                 join d in db.Departments on e.Department_ID equals d.ID
                                 join ro in db.Roles on r.RoleId equals ro.ID
                                 where r.AccountActivation == true
                                 select new ApproveRegistrationViewModel
                                 {
                                     FullName = e.FirstName + " " + e.SecondName + " " + e.ThirdName + " " + e.FourthName,
                                     UserName = r.UserName,
                                     Password = r.Password,
                                     DepartmentName = d.DepartmentName,
                                     RoleName = ro.RoleNameAr,
                                     ID = r.ID
                                 }).ToList();

                    return View(query);
                }
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}