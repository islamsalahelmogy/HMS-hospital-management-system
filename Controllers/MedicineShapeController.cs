using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class MedicineShapeController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("MedicineShapeController_Index") && Session["UserId"] != null)
            {
                return View(db.Medicine_Shapes.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            if (Settings.check("MedicineShapeController_Add") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Add(Medicine_Shape medicine_Shape)
        {
            try
            {
                db.Medicine_Shapes.Add(medicine_Shape);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Shapes.ToList());

            }
            catch (Exception)
            {
                return View(medicine_Shape);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("MedicineShapeController_Edit") && Session["UserId"] != null)
            {
                Medicine_Shape medicine_Shape = db.Medicine_Shapes.FirstOrDefault(w => w.ID == id);
                return View(medicine_Shape);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Edit(Medicine_Shape medicine_Shape)
        {
            try
            {
                Medicine_Shape oldMedicineShape = db.Medicine_Shapes.FirstOrDefault(w => w.ID == medicine_Shape.ID);
                oldMedicineShape.Name_Arabic = medicine_Shape.Name_Arabic;
                oldMedicineShape.Name_English = medicine_Shape.Name_English;
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Shapes.ToList());
            }
            catch (Exception)
            {
                return View(medicine_Shape);
            }
        }

        #endregion
        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Medicine_Shape medicine_Shape = db.Medicine_Shapes.FirstOrDefault(w => w.ID == id);
                db.Medicine_Shapes.Remove(medicine_Shape);
                db.SaveChanges();
                return RedirectToAction("Index", db.Medicine_Shapes.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Index", db.Medicine_Shapes.ToList());
            }
        }


        #endregion
    }
}