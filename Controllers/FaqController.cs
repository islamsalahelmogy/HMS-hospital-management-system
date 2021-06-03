using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using System.IO;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class FaqController : Controller
    {
        private HospitalContext db = new HospitalContext();
        // GET: Faq

        public ActionResult Display()
        {

            var F = db.FaQ.ToList();
            return View(F);
        }

        [HttpGet]
        public ActionResult RegFaq()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegFaq(Faq f, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path);
                    f.Image = Image.FileName;
                }

                db.FaQ.Add(f);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(f);

            }
        }


        public ActionResult Index()
        {
            if (Settings.check("FaqController_Index") && Session["UserId"] != null)
            {
                var F = db.FaQ.ToList();
                return View(F);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }


        public ActionResult Delete(int id)
        {
            Faq faq = db.FaQ.FirstOrDefault(w => w.Id == id);
            db.FaQ.Remove(faq);
            db.SaveChanges();
            return RedirectToAction("Index", db.FaQ.ToList());
        }
    }
}
