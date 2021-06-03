using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{

    public class EmployeeController : Controller
    {
        HospitalContext DB = new HospitalContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("EmployeeController_Index") && Session["UserId"] != null)
            {
                return View(DB.Employees.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        #region PartialViews
        [HttpGet]
        public ActionResult AddEmp()
        {
            if (Settings.check("EmployeeController_AddEmp") && Session["UserId"] != null)
            {
                ViewBag.career = new SelectList(DB.Careers, "ID", "CareerType", 1);
                ViewBag.department = new SelectList(DB.Departments, "ID", "DepartmentName", 1);
                ViewBag.Role = new SelectList(DB.Roles.ToList(), "ID", "RoleNameAr", 1);
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");

        }

        [HttpPost]
        public ActionResult AddEmp(Employee newEmp, HttpPostedFileBase Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (DB.Employees.Any(ww => ww.SSN.Equals(newEmp.SSN)))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (Image != null)
                        {
                            string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(Image.FileName));
                            Image.SaveAs(path);
                            newEmp.Image = Image.FileName;
                        }
                        DB.Employees.Add(newEmp);
                        DB.SaveChanges();
                        Registration register = new Registration();
                        register.ID = newEmp.ID;
                        register.UserName = newEmp.UserName;
                        register.Password = newEmp.Password;
                        register.RoleId = newEmp.RoleId;
                        register.AccountActivation = false;
                        DB.Registrations.Add(register);
                        DB.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(newEmp);

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("EmployeeController_Edit") && Session["UserId"] != null)
            {
                var emp = DB.Employees.Single(ww => ww.ID == id);
                ViewBag.career = new SelectList(DB.Careers, "ID", "CareerType", emp.Career_ID);
                ViewBag.department = new SelectList(DB.Departments, "ID", "DepartmentName", emp.Department_ID);
                return View(emp);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Employee newemp, HttpPostedFileBase Image)
        {
            try
            {
                var oldemp = DB.Employees.Single(ww => ww.ID == newemp.ID);

                if (Image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path);
                    newemp.Image = Image.FileName;
                    oldemp.Image = newemp.Image;
                }
                oldemp.FirstName = newemp.FirstName;
                oldemp.SecondName = newemp.SecondName;
                oldemp.ThirdName = newemp.ThirdName;
                oldemp.FourthName = newemp.FourthName;
                oldemp.Department_ID = newemp.Department_ID;
                oldemp.Career_ID = newemp.Career_ID;
                oldemp.SSN = newemp.SSN;

                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(newemp);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var emp = DB.Employees.FirstOrDefault(w => w.ID == id);
            return View(emp);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var reg = DB.Registrations.Where(w => w.ID == id).FirstOrDefault();
                DB.Registrations.Remove(reg);
                DB.SaveChanges();
                var emp = DB.Employees.Single(ww => ww.ID == id);
                DB.Employees.Remove(emp);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        #endregion

        //public JsonResult GetSearchingData(string SearchValue)
        //{
        //    try
        //    {
        //        var emps = DB.Employees.Where(x => x.FirstName.Contains(SearchValue) || SearchValue == null).ToList();

        //        return Json(emps, JsonRequestBehavior.AllowGet);
        //    }
        //    catch
        //    {
        //        return Json("", JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}