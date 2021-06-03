using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class CareerController : Controller
    {

        HospitalContext DB = new HospitalContext();
        // GET: career
        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("CareerController_Index") && Session["UserId"] != null)
            {
                return View(DB.Careers.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpGet]
        public ActionResult AddCareer()
        {
            if (Settings.check("CareerController_AddCareer") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddCareer(Career newCareer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (DB.Careers.Any(ww => ww.CareerType.Equals(newCareer.CareerType)))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        DB.Careers.Add(newCareer);
                        DB.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(newCareer);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("CareerController_Edit") && Session["UserId"] != null)
            {
                var career = DB.Careers.Single(ww => ww.ID == id);
                return View(career);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Career newcareer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldcareer = DB.Careers.Single(ww => ww.ID == newcareer.ID);
                    oldcareer.CareerType = newcareer.CareerType;
                    DB.SaveChanges();
                    return RedirectToAction("Index");

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(newcareer);

            }
        }

        public ActionResult Delete(int id)
        {
            var career = DB.Careers.Single(ww => ww.ID == id);
            DB.Careers.Remove(career);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}