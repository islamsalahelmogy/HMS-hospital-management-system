using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class ClinicRegisterController : Controller
    {
        private HospitalContext db = new HospitalContext();
        [HttpGet]
        public ActionResult ClinicRegister()
        {
            if (Settings.check("ClinicRegisterController_ClinicRegister") && Session["UserId"] != null)
            {
                if (TempData["x"] == null)
                {
                    List<Department> d = db.Departments.ToList();
                    ViewBag.DepartmentId = new SelectList(db.Departments.ToList(), "ID", "DepartmentName");
                    return View();
                }
                else
                {
                    ViewBag.mess = (string)TempData["x"];
                    ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "DepartmentName");
                    return View();
                }
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        public JsonResult GetSearchingData(string SearchValue)
        {
            var patient = db.Patients.FirstOrDefault(w => w.ID_Nozom == 0);
            try
            {
                int Id = Convert.ToInt32(SearchValue);
                patient = db.Patients.FirstOrDefault(w => w.ID_Nozom == Id);
                return Json(patient, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(patient, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Register(string SearchValue, string ChooseDepatment)
        {
            //try
            //{
            int PatientId = int.Parse(SearchValue);
            int DepartmentId = int.Parse(ChooseDepatment);
            var qyr = db.Patients.Where(s => s.ID_Nozom == PatientId).FirstOrDefault();
            Clinic_Register Clinic_Register = new Clinic_Register();
            //return count 0 or 1
            int Cliniccount = db.Clinic_Registers.Where(s => s.Id_patient == PatientId).Count();
            if (Cliniccount == 0)
            {
                Clinic_Register.ID_Frequancy = 1;
            }
            else
            {
                int max = db.Clinic_Registers.Where(s => s.Id_patient == PatientId).Max(s => s.ID_Frequancy);
                Clinic_Register.ID_Frequancy = max + 1;
            }
            Clinic_Register.TimeComing = DateTime.Now.Date;
            Clinic_Register.Id_patient = PatientId;
            Clinic_Register.DateIncoming = DateTime.Now.Date;
            Clinic_Register.DepartmentId = DepartmentId;
            //Clinic_Register.UserId=int.Parse(Session["UserId"].ToString());
            DateTime date = DateTime.Now.Date;
            int exist = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == DepartmentId).Count();
            if (exist == 0)
            {
                Clinic_Register.counterNumber = 1;
            }
            else
            {
                int? max = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == DepartmentId)
                .Max(s => s.counterNumber);
                Clinic_Register.counterNumber = max + 1;
            }

            db.Clinic_Registers.Add(Clinic_Register);
            db.SaveChanges();

            //var registered = new { counterNumber = Clinic_Register.counterNumber, department = Clinic_Register.Department.DepartmentName };
            var registered = Clinic_Register;
            try
            {
                return Json(registered, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(registered, JsonRequestBehavior.AllowGet);
            }
            //}
            //catch
            //{
            //    return Json("لا يمكن حجز عيادة لهذ المريض لنفس القسم مرتين", JsonRequestBehavior.AllowGet);
            //}
        }

        public ActionResult Index()
        {
            if (Settings.check("ClinicRegisterController_Index") && Session["UserId"] != null)
            {
                if (TempData["status"] != null)
                {
                    ViewBag.Message = "تم الحجز بنجاح ";
                    TempData.Remove("status");
                }
                ViewBag.sext = db.Sex_Types.ToList();
                ViewBag.depts = db.Departments.ToList();
                var x = db.RequestRegisterClinic.Where(w => w.Status == true).ToList();
                return View(x);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }
        public ActionResult Edit(int id)
        {
            var rgc = db.RequestRegisterClinic.FirstOrDefault(w => w.ID == id);
            var p = db.Patients.FirstOrDefault(w => w.SSN == rgc.SSN);
            Clinic_Register clinic_Register = new Clinic_Register();

            if (p == null)
            {
                var patient = new Patient { FirstName = rgc.FirstName, SecondName = rgc.SecondName, ThirdName = rgc.ThirdName, FourthName = rgc.FourthName, SSN = rgc.SSN, BirthDate = rgc.BirthDate, Phone = rgc.Phone, IdType = rgc.Sex_id, Status = true };
                db.Patients.Add(patient);
                db.SaveChanges();

                int Cliniccount = db.Clinic_Registers.Where(s => s.Id_patient == patient.ID_Nozom).Count();
                if (Cliniccount == 0)
                {
                    clinic_Register.ID_Frequancy = 1;
                }
                else
                {
                    int max = db.Clinic_Registers.Where(s => s.Id_patient == patient.ID_Nozom).Max(s => s.ID_Frequancy);
                    clinic_Register.ID_Frequancy = max + 1;
                }
                clinic_Register.Id_patient = (int)patient.ID_Nozom;
                clinic_Register.DateIncoming = DateTime.Now.Date;
                var date = DateTime.Now.Date;

                int exist = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == rgc.Department_Id).Count();
                if (exist == 0)
                {
                    clinic_Register.counterNumber = 1;
                }
                else
                {
                    int? max = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == rgc.Department_Id)
                    .Max(s => s.counterNumber);
                    clinic_Register.counterNumber = max + 1;
                }
                clinic_Register.DepartmentId = rgc.Department_Id;
                rgc.Status = false;
                db.Clinic_Registers.Add(clinic_Register);
                db.SaveChanges();
                TempData["status"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                rgc.Status = false;
                db.SaveChanges();
                int Cliniccount = db.Clinic_Registers.Where(s => s.Id_patient == p.ID_Nozom).Count();
                if (Cliniccount == 0)
                {
                    clinic_Register.ID_Frequancy = 1;
                }
                else
                {
                    int max = db.Clinic_Registers.Where(s => s.Id_patient == p.ID_Nozom).Max(s => s.ID_Frequancy);
                    clinic_Register.ID_Frequancy = max + 1;
                }
                clinic_Register.Id_patient = (int)p.ID_Nozom;
                clinic_Register.DateIncoming = DateTime.Now.Date;
                var date = DateTime.Now.Date;

                int exist = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == rgc.Department_Id).Count();
                if (exist == 0)
                {
                    clinic_Register.counterNumber = 1;
                }
                else
                {
                    int? max = db.Clinic_Registers.Where(s => s.DateIncoming == date && s.DepartmentId == rgc.Department_Id)
                    .Max(s => s.counterNumber);
                    clinic_Register.counterNumber = max + 1;
                }
                clinic_Register.DepartmentId = rgc.Department_Id;
                db.Clinic_Registers.Add(clinic_Register);
                db.SaveChanges();
                TempData["status"] = "Success";
                return RedirectToAction("Index");
            }
        }
    }
}