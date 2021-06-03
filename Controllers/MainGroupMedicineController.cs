using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class MainGroupMedicineController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("MainGroupMedicineController_Index") && Session["UserId"] != null)
            {
                return View(db.Main_Group_Medicines.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (Settings.check("MainGroupMedicineController_Add") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Add(Main_Group_Medicine main_Group)
        {
            try
            {
                db.Main_Group_Medicines.Add(main_Group);
                db.SaveChanges();
                return RedirectToAction("Index", db.Main_Group_Medicines.ToList());
            }
            catch (Exception)
            {
                return View(main_Group);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("MainGroupMedicineController_Edit") && Session["UserId"] != null)
            {
                Main_Group_Medicine main_Group = db.Main_Group_Medicines.FirstOrDefault(w => w.ID == id);
                return View(main_Group);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Edit(Main_Group_Medicine main_Group)
        {
            try
            {
                Main_Group_Medicine oldMainGroup = db.Main_Group_Medicines.FirstOrDefault(w => w.ID == main_Group.ID);
                oldMainGroup.NameArabic = main_Group.NameArabic;
                oldMainGroup.NameEnglish = main_Group.NameEnglish;
                db.SaveChanges();
                return RedirectToAction("Index", db.Main_Group_Medicines.ToList());

            }
            catch (Exception)
            {
                return View(main_Group);
            }
        }

        #endregion
        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Main_Group_Medicine main_Group = db.Main_Group_Medicines.FirstOrDefault(w => w.ID == id);
                db.Main_Group_Medicines.Remove(main_Group);
                db.SaveChanges();
                return RedirectToAction("Index", db.Main_Group_Medicines.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Index", db.Main_Group_Medicines.ToList());
            }
        }


        #endregion
    }
}