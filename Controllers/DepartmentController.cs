using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class DepartmentController : Controller
    {
        HospitalContext DB = new HospitalContext();

        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("DepartmentController_Index") && Session["UserId"] != null)
            {
                return View(DB.Departments.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpGet]
        public ActionResult AddDept()
        {
            if (Settings.check("DepartmentController_AddDept") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddDept(Department newDept)
        {
            if (ModelState.IsValid)
            {
                if (DB.Departments.Any(ww => ww.DepartmentName.Equals(newDept.DepartmentName)))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    DB.Departments.Add(newDept);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("DepartmentController_Edit") && Session["UserId"] != null)
            {
                var dept = DB.Departments.Single(ww => ww.ID == id);
                return View(dept);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Department newdept)
        {
            var olddept = DB.Departments.Single(ww => ww.ID == newdept.ID);
            olddept.DepartmentName = newdept.DepartmentName;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dept = DB.Departments.Single(ww => ww.ID == id);
            DB.Departments.Remove(dept);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}