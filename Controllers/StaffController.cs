using HMS_ITI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class StaffController : Controller
    {
        private HospitalContext db = new HospitalContext();
        // GET: Faq
        public ActionResult DisplayAboutUs()
        {
            var F = db.Staffs.ToList();
            return View(F);
        }

        public ActionResult RegStaff()
        {
            if (Settings.check("StaffController_RegStaff") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult RegStaff(Staff S, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path);
                    S.Image = Image.FileName;
                }

                db.Staffs.Add(S);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(S);
            }

        }
        public ActionResult Index()
        {
            if (Settings.check("StaffController_Index") && Session["UserId"] != null)
            {
                var F = db.Staffs.ToList();
                return View(F);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }


        public ActionResult Delete(int id)
        {
            Staff S = db.Staffs.FirstOrDefault(w => w.Id == id);
            db.Staffs.Remove(S);
            db.SaveChanges();
            return RedirectToAction("Index", db.Staffs.ToList());
        }
    }
}

