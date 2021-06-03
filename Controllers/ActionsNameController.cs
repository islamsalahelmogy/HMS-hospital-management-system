using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class ActionsNameController : Controller
    {
        // GET: ActionsName
        HospitalContext DB = new HospitalContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("ActionsNameController_Index") && Session["UserId"] != null)
            {
                return View(DB.ActionsNames.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpGet]
        public ActionResult AddAction()
        {
            if (Settings.check("ActionsNameController_AddAction") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddAction(ActionsName newaction)
        {
            if (ModelState.IsValid)
            {
                if (DB.ActionsNames.Any(ww => ww.ActionName.Equals(newaction.ActionName)))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    DB.ActionsNames.Add(newaction);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Settings.check("ActionsNameController_Edit") && Session["UserId"] != null)
            {
                var action = DB.ActionsNames.Single(ww => ww.ID == id);
                return View(action);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ActionsName newaction)
        {
            if (ModelState.IsValid)
            {
                var oldaction = DB.ActionsNames.Single(ww => ww.ID == newaction.ID);
                oldaction.ActionName = newaction.ActionName;
                oldaction.ShowName = newaction.ShowName;
                DB.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var action = DB.ActionsNames.Single(ww => ww.ID == id);
            DB.ActionsNames.Remove(action);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}