using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class PartGroupMedicineController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("PartGroupMedicineController_Index") && Session["UserId"] != null)
            {
                return View(db.Part_Group_Medicines.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (Settings.check("PartGroupMedicineController_Add") && Session["UserId"] != null)
            {
                ViewBag.maingroup = new SelectList(db.Main_Group_Medicines.ToList(), "ID", "NameEnglish", 1);
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Add(Part_Group_Medicine part_Group)
        {
            try
            {

                ViewBag.maingroup = new SelectList(db.Main_Group_Medicines.ToList(), "ID", "NameEnglish", part_Group.MainGroupId);
                db.Part_Group_Medicines.Add(part_Group);
                db.SaveChanges();
                return RedirectToAction("Index", db.Part_Group_Medicines.ToList());

            }
            catch (Exception)
            {
                return View(part_Group);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("PartGroupMedicineController_Edit") && Session["UserId"] != null)
            {
                Part_Group_Medicine part_Group = db.Part_Group_Medicines.FirstOrDefault(w => w.ID == id);
                ViewBag.maingroup = new SelectList(db.Main_Group_Medicines.ToList(), "ID", "NameEnglish", part_Group.MainGroupId);
                return View(part_Group);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Edit(Part_Group_Medicine part_Group)
        {
            try
            {
                ViewBag.maingroup = new SelectList(db.Main_Group_Medicines.ToList(), "ID", "NameEnglish", part_Group.MainGroupId);
                Part_Group_Medicine oldPartGroup = db.Part_Group_Medicines.FirstOrDefault(w => w.ID == part_Group.ID);
                oldPartGroup.NameArabic = part_Group.NameArabic;
                oldPartGroup.NameEnglish = part_Group.NameEnglish;
                oldPartGroup.MainGroupId = part_Group.MainGroupId;
                db.SaveChanges();
                return RedirectToAction("Index", db.Part_Group_Medicines.ToList());
            }
            catch (Exception)
            {
                return View(part_Group);
            }
        }

        #endregion
        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Part_Group_Medicine part_Group = db.Part_Group_Medicines.FirstOrDefault(w => w.ID == id);
                db.Part_Group_Medicines.Remove(part_Group);
                db.SaveChanges();
                return RedirectToAction("Index", db.Part_Group_Medicines.ToList());

            }
            catch (Exception)
            {
                return RedirectToAction("Index", db.Part_Group_Medicines.ToList());
            }
        }


        #endregion
    }
}