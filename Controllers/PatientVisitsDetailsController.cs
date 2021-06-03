using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class PatientVisitsDetailsController : Controller
    {
        HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            if (Settings.check("PatientVisitsDetailsController_Index") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        [HttpGet]
        public ActionResult search(string Search)
        {
            int Id = Convert.ToInt32(Search);
            var cr = db.Clinic_Registers.Where(w => w.Id_patient == Id);
            var p = new List<PatientVisitsViewModel>();

            foreach (var item in cr)
            {
                var pv = new PatientVisitsViewModel();
                pv.ID_Nozom = item.Id_patient;
                pv.DepartmentName = item.Department.DepartmentName;
                pv.date = (DateTime)item.DateIncoming;
                //medicine
                var med = db.Register_Medicines.Where(w => w.Id_Nozom == item.Id_patient && w.Id_Frequancy == item.ID_Frequancy);
                foreach (var item2 in med)
                {
                    if (item2 != null)
                    {
                        var m = db.Medicines.FirstOrDefault(w => w.ID == item2.ID_Medicin);
                        pv.register_Medicines.Add(m.MedNameArabic);

                    }
                }

                //diagnosis
                var y = db.Diagnosis.FirstOrDefault(w => w.Id_Nozom == item.Id_patient && w.Id_Frequancy == item.ID_Frequancy);
                if (y != null)
                {
                    pv.diagnoses = y._Diagnosis;
                }
                else
                {
                    pv.diagnoses = "";
                }
                //critical data
                var x = db.Crit_Datas.Where(w => w.Id_Nozom == item.Id_patient && w.Id_Frequancy == item.ID_Frequancy);
                foreach (var item3 in x)
                {
                    if (item3 != null)
                    {
                        var cd = db.Critical_Datas.FirstOrDefault(w => w.ID == item3.Id_CriticalData);
                        pv.critical_Datas.Add(cd.Critic_Data);
                    }
                }


                p.Add(pv);
            }
            return View("Index", p.OrderByDescending(w => w.date).ToList());
        }

    }
}