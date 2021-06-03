using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class DailyRegisteredPatientsController : Controller
    {
        private HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("DailyRegisteredPatientsController_Index") && Session["UserId"] != null)
            {
                DateTime date = DateTime.Now.Date;
                var qyr = (from CR in db.Clinic_Registers
                           join P in db.Patients on CR.Id_patient equals P.ID_Nozom
                           join d in db.Departments on CR.DepartmentId equals d.ID
                           where CR.DateIncoming == date
                           select new RegisteredViewModel
                           {
                               ID_Nozom = CR.Id_patient,
                               FullName = P.FirstName + " " + P.SecondName + " " + P.ThirdName + " " + P.FourthName,
                               TimeComing = CR.TimeComing,
                               counterNumber = CR.counterNumber,
                               ID_Frequancy = CR.ID_Frequancy,
                               DepartmentName = d.DepartmentName
                           }).ToList();
                return View(qyr);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        public JsonResult GetSearchingData(string SearchValue)
        {
            try
            {
                int Id = Convert.ToInt32(SearchValue);
                DateTime date = DateTime.Now.Date;
                var qyr = (from CR in db.Clinic_Registers
                           join P in db.Patients on CR.Id_patient equals P.ID_Nozom
                           join d in db.Departments on CR.DepartmentId equals d.ID
                           where CR.DateIncoming == date && CR.Id_patient == Id
                           select new RegisteredViewModel
                           {
                               ID_Nozom = CR.Id_patient,
                               FullName = P.FirstName + " " + P.SecondName + " " + P.ThirdName + " " + P.FourthName,
                               TimeComing = CR.TimeComing,
                               counterNumber = CR.counterNumber,
                               ID_Frequancy = CR.ID_Frequancy,
                               DepartmentName = d.DepartmentName
                           }).ToList();
                return Json(qyr, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}