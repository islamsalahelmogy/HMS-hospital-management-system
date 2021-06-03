using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class MedicineCompanyController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("MedicineCompanyController_Index") && Session["UserId"] != null)
            {
                return View(db.Medicine_Companies.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (Settings.check("MedicineCompanyController_Add") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Add(Medicine_Company medicine_Company)
        {
            try
            {
                db.Medicine_Companies.Add(medicine_Company);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Companies.ToList());
            }
            catch (Exception)
            {
                return View(medicine_Company);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("MedicineCompanyController_Edit") && Session["UserId"] != null)
            {
                Medicine_Company medicine_Company = db.Medicine_Companies.FirstOrDefault(w => w.ID == id);
                return View(medicine_Company);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Edit(Medicine_Company medicine_Company)
        {
            try
            {
                Medicine_Company oldMedicineCompany = db.Medicine_Companies.FirstOrDefault(w => w.ID == medicine_Company.ID);
                oldMedicineCompany.Name_Company = medicine_Company.Name_Company;
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Companies.ToList());
            }
            catch (Exception)
            {
                return View(medicine_Company);
            }
        }

        #endregion
        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Medicine_Company medicine_Company = db.Medicine_Companies.FirstOrDefault(w => w.ID == id);
                db.Medicine_Companies.Remove(medicine_Company);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Companies.ToList());

            }
            catch (Exception)
            {
                return RedirectToAction("Index", db.Medicine_Companies.ToList());
            }
        }


        #endregion
    }
}