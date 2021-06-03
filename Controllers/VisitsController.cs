using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class VisitsController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Visits
        public ActionResult Index()
        {
            if (Settings.check("VisitsController_Index") && Session["UserId"] != null)
            {
                var d = new DatesViewModel();
                return View(d);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        //public ActionResult setdata(DatesViewModel dvm)
        //{

        //}
        [HttpPost]
        public ActionResult setdata(DatesViewModel dvm)
        {
            //DateTime start = new DateTime(ticks);
            //DateTime end = new DateTime(ed);
            var cr = db.Clinic_Registers.Where(w => w.DateIncoming >= dvm.StartDate && w.DateIncoming <= dvm.EndDate);
            var p = new List<patientVisitswithnamesViewModel>();

            foreach (var item in cr)
            {
                var pv = new patientVisitswithnamesViewModel();
                pv.ID_Nozom = item.Id_patient;
                pv.DepartmentName = item.Department.DepartmentName;
                pv.date = (DateTime)item.DateIncoming;
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

                var patient = db.Patients.FirstOrDefault(w => w.ID_Nozom == item.Id_patient);
                pv.FName = patient.FirstName;
                pv.sName = patient.SecondName;
                pv.tName = patient.ThirdName;
                pv.FoName = patient.FourthName;
                p.Add(pv);
            }
            ViewBag.p = p;
            return View("Index");
        }
    }
}