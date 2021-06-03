using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class Recommendation_AdviceController : Controller
    {
        private HospitalContext db = new HospitalContext();

        public ActionResult Index()
        {
            if (Settings.check("Recommendation_AdviceController_Index") && Session["UserId"] != null)
            {
                return View(db.Recommendation_Advices.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        #region Add
        public ActionResult Create()
        {
            if (Settings.check("Recommendation_AdviceController_Create") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpPost]
        public ActionResult Create(Recommendation_Advice recommendation_Advice)
        {
            if (ModelState.IsValid)
            {
                db.Recommendation_Advices.Add(recommendation_Advice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recommendation_Advice);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int? id)
        {
            if (Settings.check("Recommendation_AdviceController_Edit") && Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Recommendation_Advice recommendation_Advice = db.Recommendation_Advices.Find(id);
                if (recommendation_Advice == null)
                {
                    return HttpNotFound();
                }
                return View(recommendation_Advice);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult Edit(Recommendation_Advice recommendation_Advice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommendation_Advice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recommendation_Advice);
        }
        #endregion


        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommendation_Advice recommendation_Advice = db.Recommendation_Advices.Find(id);
            if (recommendation_Advice == null)
            {
                return HttpNotFound();
            }
            db.Recommendation_Advices.Remove(recommendation_Advice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


    }
}
