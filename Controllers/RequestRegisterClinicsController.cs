using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class RequestRegisterClinicsController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: RequestRegisterClinics
        public ActionResult Index()
        {
            var S = db.Sex_Types.ToList();
            var D = db.Departments.ToList();
            ViewBag.sext = db.Sex_Types.ToList();
            ViewBag.depts = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(RequestRegisterClinic obj)
        {
            obj.Status = true;
            db.RequestRegisterClinic.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddClinicReg()
        {
            var S = db.Sex_Types.ToList();
            var D = db.Departments.ToList();

            ViewBag.sext = db.Sex_Types.ToList();
            ViewBag.depts = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddClinicReg(RequestRegisterClinic obj)
        {
            
            db.RequestRegisterClinic.Add(obj);
            db.SaveChanges();
            return RedirectToAction("AddClinicReg");
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact c)
        {
            db.Contacts.Add(c);
            db.SaveChanges();
            return Redirect("Contact");
        }

        public ActionResult DeleteClinic(int id)
        {
            RequestRegisterClinic S = db.RequestRegisterClinic.FirstOrDefault(w => w.ID == id);
            db.RequestRegisterClinic.Remove(S);
            db.SaveChanges();
            return RedirectToAction("Index", db.RequestRegisterClinic.ToList());
        }

        public ActionResult DeleteContact(int id)
        {
            Contact C = db.Contacts.FirstOrDefault(w => w.ID == id);
            db.Contacts.Remove(C);
            db.SaveChanges();
            return RedirectToAction("DisplayContactMessage", db.Contacts.ToList());
        }
        public ActionResult DisplayContactMessage()
        {
            if (Settings.check("RequestRegisterClinicsController_DisplayContactMessage") && Session["UserId"] != null)
            {
                var R = db.Contacts.ToList();
                return View(R);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        public ActionResult DisplayRegesterClinic()
        {
            var R = db.RequestRegisterClinic.ToList();
            return View(R);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
