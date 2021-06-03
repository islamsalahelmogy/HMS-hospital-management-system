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
    public class Critical_DataController : Controller
    {
        private HospitalContext db = new HospitalContext();

        public ActionResult Index()
        {
            if (Settings.check("Critical_DataController_Index") && Session["UserId"] != null)
            {
                return View(db.Critical_Datas.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }


        #region Add
        public ActionResult Create()
        {
            if (Settings.check("Critical_DataController_Create") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Create(Critical_Data critical_Data)
        {
            if (ModelState.IsValid)
            {
                db.Critical_Datas.Add(critical_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(critical_Data);
        }
        #endregion

        #region Update
        public ActionResult Edit(int? id)
        {
            if (Settings.check("Critical_DataController_Edit") && Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Critical_Data critical_Data = db.Critical_Datas.Find(id);
                if (critical_Data == null)
                {
                    return HttpNotFound();
                }
                return View(critical_Data);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Critical_Data critical_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(critical_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(critical_Data);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critical_Data critical_Data = db.Critical_Datas.Find(id);
            if (critical_Data == null)
            {
                return HttpNotFound();
            }
            db.Critical_Datas.Remove(critical_Data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion



    }
}
