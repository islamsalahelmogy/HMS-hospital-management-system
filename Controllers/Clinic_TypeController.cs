using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class Clinic_TypeController : Controller
    {
        // GET: Clinic_Type
        HospitalContext DB = new HospitalContext();

        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("Clinic_TypeController_Index") && Session["UserId"] != null)
            {
                return PartialView(DB.Clinic_Types.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpGet]
        public ActionResult AddClinic_Type()
        {
            if (Settings.check("Clinic_TypeController_AddClinic_Type") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddClinic_Type(Clinic_Type newClinic)
        {
            if (ModelState.IsValid)
            {
                if (DB.Clinic_Types.Any(ww => ww.Type.Equals(newClinic.Type)))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    DB.Clinic_Types.Add(newClinic);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("Clinic_TypeController_Edit") && Session["UserId"] != null)
            {
                var clinic = DB.Clinic_Types.Single(ww => ww.ID == id);
                return View(clinic);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Clinic_Type newclinic)
        {
            var oldclinic = DB.Clinic_Types.Single(ww => ww.ID == newclinic.ID);
            oldclinic.Type = newclinic.Type;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var clinic = DB.Clinic_Types.Single(ww => ww.ID == id);
            DB.Clinic_Types.Remove(clinic);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}