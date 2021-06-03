using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class PatientController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Patient
        public ActionResult Index()
        {
            if (Settings.check("PatientController_Index") && Session["UserId"] != null)
            {
                return View(db.Patients.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpGet]
        public ActionResult AddPatient()
        {
            if (Settings.check("PatientController_AddPatient") && Session["UserId"] != null)
            {
                ViewBag.nation = new SelectList(db.Nationalities, "ID", "Nationa", 1);
                ViewBag.sex = new SelectList(db.Sex_Types, "ID", "TypeName", 1);
                ViewBag.rel = new SelectList(db.Religions, "ID", "_Religion", 1);
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddPatient(Patient newpat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Patients.Any(ww => ww.SSN.Equals(newpat.SSN)))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        newpat.Status = true;
                        db.Patients.Add(newpat);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(newpat);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("PatientController_Edit") && Session["UserId"] != null)
            {
                var pat = db.Patients.Single(ww => ww.ID_Nozom == id);
                ViewBag.nation = new SelectList(db.Nationalities, "ID", "Nationa", pat.IdNationalty);
                ViewBag.sex = new SelectList(db.Sex_Types, "ID", "TypeName", pat.IdType);
                ViewBag.rel = new SelectList(db.Religions, "ID", "_Religion", pat.IdReligion);
                return View(pat);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Patient newpat)
        {
            try
            {
                var oldpat = db.Patients.Single(ww => ww.ID_Nozom == newpat.ID_Nozom);
                oldpat.FirstName = newpat.FirstName;
                oldpat.SecondName = newpat.SecondName;
                oldpat.ThirdName = newpat.ThirdName;
                oldpat.FourthName = newpat.FourthName;
                oldpat.SSN = newpat.SSN;
                oldpat.Phone = newpat.Phone;
                oldpat.IdNationalty = newpat.IdNationalty;
                oldpat.IdType = newpat.IdType;
                oldpat.IdReligion = newpat.IdReligion;
                oldpat.BirthDate = newpat.BirthDate;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch (Exception)
            {

                return View(newpat);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var pat = db.Patients.Single(ww => ww.ID_Nozom == id);
                db.Patients.Remove(pat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetSearchingData(string Search)
        {
            try
            {
                if (Search == "")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Patient patient = db.Patients.Where(x => x.SSN == Search).FirstOrDefault();
                    ViewBag.p = patient;
                    return View("Index");
                }
            }
            catch (FormatException)
            {
                return RedirectToAction("Index");
            }

        }
    }
}