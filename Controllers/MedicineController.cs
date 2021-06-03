using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class MedicineController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("MedicineController_Index") && Session["UserId"] != null)
            {
                return View(db.Medicines.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (Settings.check("MedicineController_Add") && Session["UserId"] != null)
            {
                ViewBag.medcmp = new SelectList(db.Medicine_Companies.ToList(), "ID", "Name_Company", 1);
                ViewBag.medshp = new SelectList(db.Medicine_Shapes.ToList(), "ID", "Name_English", 1);
                ViewBag.medprt = new SelectList(db.Part_Group_Medicines.ToList(), "ID", "NameEnglish", 1);
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Add(Medicine medicine)
        {
            try
            {
                ViewBag.medcmp = new SelectList(db.Medicine_Companies.ToList(), "ID", "Name_Company", medicine.CompanyId);
                ViewBag.medshp = new SelectList(db.Medicine_Shapes.ToList(), "ID", "Name_English", medicine.ShapeId);
                ViewBag.medprt = new SelectList(db.Part_Group_Medicines.ToList(), "ID", "NameEnglish", medicine.PartGroupId);
                medicine.DateMedicinRegister = DateTime.Now;
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicines.ToList());
            }
            catch (Exception)
            {
                return View(medicine);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("MedicineController_Edit") && Session["UserId"] != null)
            {
                Medicine medicine = db.Medicines.FirstOrDefault(w => w.ID == id);
                ViewBag.medcmp = new SelectList(db.Medicine_Companies.ToList(), "ID", "Name_Company", medicine.CompanyId);
                ViewBag.medshp = new SelectList(db.Medicine_Shapes.ToList(), "ID", "Name_English", medicine.ShapeId);
                ViewBag.medprt = new SelectList(db.Part_Group_Medicines.ToList(), "ID", "NameEnglish", medicine.PartGroupId);
                return View(medicine);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Medicine medicine)
        {
            try
            {
                ViewBag.medcmp = new SelectList(db.Medicine_Companies.ToList(), "ID", "Name_Company", medicine.CompanyId);
                ViewBag.medshp = new SelectList(db.Medicine_Shapes.ToList(), "ID", "Name_English", medicine.ShapeId);
                ViewBag.medprt = new SelectList(db.Part_Group_Medicines.ToList(), "ID", "NameEnglish", medicine.PartGroupId);
                Medicine oldmedicine = db.Medicines.FirstOrDefault(w => w.ID == medicine.ID);
                oldmedicine.IDMedicin = medicine.IDMedicin;
                oldmedicine.PartGroupId = medicine.PartGroupId;
                oldmedicine.CompanyId = medicine.CompanyId;
                oldmedicine.ShapeId = medicine.ShapeId;
                oldmedicine.MedNameArabic = medicine.MedNameArabic;
                oldmedicine.MedNameEnglish = medicine.MedNameEnglish;
                oldmedicine.DateMedicinRegister = medicine.DateMedicinRegister;
                oldmedicine.AllowedCurrent = medicine.AllowedCurrent;
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicines.ToList());
            }
            catch (Exception)
            {
                return View(medicine);
            }
        }

        #endregion


        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Medicine medicine = db.Medicines.FirstOrDefault(w => w.ID == id);
                db.Medicines.Remove(medicine);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicines.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Index", db.Medicines.ToList());
            }
        }
        #endregion


    }
}