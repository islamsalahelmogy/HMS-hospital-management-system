using HMS_ITI.Models;
using HMS_ITI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS_ITI.Controllers
{
    public class Doctor_SheetController : Controller
    {
        HospitalContext DB = new HospitalContext();
        public ActionResult Index(string ID_Nozom)
        {
            //if (Settings.check("Doctor_SheetControllerController_Index") && Session["UserId"] != null)
            //{
                DateTime date = DateTime.Now.Date;
                try
                {
                    if (ID_Nozom == null)
                    {
                        int userid = int.Parse(Session["UserId"].ToString());
                        var emp = DB.Employees.FirstOrDefault(w => w.ID == userid);
                        var patients =
                             (from cr in DB.Clinic_Registers
                              join p in DB.Patients on cr.Id_patient equals p.ID_Nozom
                              where cr.DateIncoming == date && cr.DepartmentId == emp.Department_ID
                              select new PatientViewmodel
                              {
                                  ID_Nozom = p.ID_Nozom,
                                  PatientName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.FourthName,
                              }).ToList();
                        return View(patients);
                    }
                    else
                    {
                        int IdNozom = int.Parse(ID_Nozom);
                        int userid = int.Parse(Session["UserId"].ToString());
                        var emp = DB.Employees.FirstOrDefault(w => w.ID == userid);
                        var patients =
                             (from cr in DB.Clinic_Registers
                              join p in DB.Patients on cr.Id_patient equals p.ID_Nozom
                              where cr.DateIncoming == date && cr.DepartmentId == emp.Department_ID && cr.Id_patient == IdNozom
                              select new PatientViewmodel
                              {
                                  ID_Nozom = p.ID_Nozom,
                                  PatientName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.FourthName,
                              }).ToList();
                        ViewBag.IdNozom = IdNozom;
                        return View(patients);
                    }

                }
                catch (Exception)
                {
                    var patients =
                         (from cr in DB.Clinic_Registers
                          join p in DB.Patients on cr.Id_patient equals p.ID_Nozom
                          where cr.DateIncoming == date
                          select new PatientViewmodel
                          {
                              ID_Nozom = p.ID_Nozom,
                              PatientName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.FourthName,
                          }).ToList();
                    return View(patients);
                }
            //}
            //return RedirectToAction("NotAuthorized", "Login");
        }
        public ActionResult Search(string ID_Nozom, string FirstName, string SecondName)
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                if (ID_Nozom != null)
                {
                    int IdNozom = int.Parse(ID_Nozom);
                    int userid = int.Parse(Session["UserId"].ToString());
                    var emp = DB.Employees.FirstOrDefault(w => w.ID == userid);
                    var patients =
                         (from cr in DB.Clinic_Registers
                          join p in DB.Patients on cr.Id_patient equals p.ID_Nozom
                          where cr.DateIncoming == date && cr.DepartmentId == emp.Department_ID && cr.Id_patient == IdNozom
                          select new PatientViewmodel
                          {
                              ID_Nozom = p.ID_Nozom,
                              PatientName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.FourthName,
                          }).ToList();
                    return View(patients);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                var patients =
                     (from cr in DB.Clinic_Registers
                      join p in DB.Patients on cr.Id_patient equals p.ID_Nozom
                      where cr.DateIncoming == date
                      select new PatientViewmodel
                      {
                          ID_Nozom = p.ID_Nozom,
                          PatientName = p.FirstName + " " + p.SecondName + " " + p.ThirdName + " " + p.FourthName,
                      }).ToList();
                return View(patients);
            }
        }

        public ActionResult patient(int id)
        {
            try
            {
                Session["id_nozom"] = id;
                var p = DB.Patients.FirstOrDefault(w => w.ID_Nozom == id);
                DateTime? d1 = p.BirthDate;
                DateTime? d2 = DateTime.Now.AddDays(-1);
                int d3 = (int)(d2 - d1).Value.TotalDays;
                p.Age = d3 / 365;
                return View(p);
            }
            catch (Exception)
            {
                return View(DB.Patients.FirstOrDefault(w => w.ID_Nozom == id));
            }
        }

        #region Rosheta
        public ActionResult GetRegMeds(int id)
        {

            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                ViewBag.med = (from rm in DB.Register_Medicines
                               join m in DB.Medicines on rm.ID_Medicin equals m.ID
                               where rm.Id_Frequancy == fre && rm.Id_Nozom == id
                               select new Register_MedicinesViewModel
                               {
                                   medcinid = m.IDMedicin,
                                   medcinname = m.MedNameEnglish,
                                   numtake = rm.Number_Of_Take_Medicine.Number,
                                   timetake1 = rm.Time_Take_Medicine1.Time,
                                   timetake2 = rm.Time_Take_Medicine2.Time
                               });
                ViewBag.mednames = new SelectList(DB.Medicines.ToList(), "ID", "MedNameEnglish");
                ViewBag.tkmed1 = new SelectList(DB.Number_Of_Take_Medicines.ToList(), "ID", "Number");
                ViewBag.tkmed2 = new SelectList(DB.Time_Take_Medicine1s.ToList(), "ID", "Time");
                ViewBag.tkmed3 = new SelectList(DB.Time_Take_Medicine2s.ToList(), "ID", "Time");
                return PartialView(DB.Register_Medicines.FirstOrDefault(w => w.Id_Nozom == id && w.Id_Frequancy == fre));
            }
            catch (Exception)
            {
                return PartialView(DB.Register_Medicines.FirstOrDefault(w => w.Id_Nozom == id));
            }
        }
        [HttpPost]
        public ActionResult RegMed(Register_Medicine register_Medicine)
        {
            int userid = int.Parse(Session["UserId"].ToString());
            int _id = int.Parse(Session["id_nozom"].ToString());
            var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
            var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
            try
            {

                var regmed = DB.Register_Medicines.Where(w => w.Id_Nozom == _id && w.Id_Frequancy == fre).FirstOrDefault(w => w.ID_Medicin == register_Medicine.ID_Medicin);
                if (regmed == null)
                {
                    register_Medicine.Id_Frequancy = fre;
                    register_Medicine.Id_Nozom = _id;
                    register_Medicine.User_Id = userid;
                    register_Medicine.Date = DateTime.Now;
                    DB.Register_Medicines.Add(register_Medicine);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });
            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        public ActionResult DeleteReg(int id)
        {
            int userid = int.Parse(Session["UserId"].ToString());
            int _id = int.Parse(Session["id_nozom"].ToString());
            var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
            var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
            try
            {
                int medid = DB.Medicines.FirstOrDefault(w => w.IDMedicin == id).ID;
                var reg = DB.Register_Medicines.Where(w => w.Id_Nozom == _id && w.Id_Frequancy == fre).FirstOrDefault(w => w.ID_Medicin == medid);
                if (reg != null)
                {
                    DB.Register_Medicines.Remove(reg);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        #endregion


        #region Tawsia Tebia
        public ActionResult GetRecAdvs(int id)
        {
            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                ViewBag.recadv = new SelectList(DB.Recommendation_Advices.ToList(), "ID", "Recommendation");
                ViewBag.adv = DB.Recommendation_Advs.Where(w => w.Id_Nozom == id).ToList();
                return PartialView(DB.Recommendation_Advs.FirstOrDefault(w => w.Id_Nozom == id && w.Id_Frequancy == fre));

            }
            catch (Exception)
            {
                return PartialView(DB.Recommendation_Advs.FirstOrDefault(w => w.Id_Nozom == id));
            }
        }

        [HttpPost]
        public ActionResult RecAdv(Recommendation_Adv recommendation)
        {
            int _id = int.Parse(Session["id_nozom"].ToString());
            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                var rec = DB.Recommendation_Advs.Where(w => w.Id_Nozom == _id && w.Id_Frequancy == fre).FirstOrDefault(w => w.Id_RecommendationAdvice == recommendation.Id_RecommendationAdvice);
                if (rec == null)
                {
                    recommendation.Date = DateTime.Now;
                    recommendation.Id_Nozom = _id;
                    recommendation.Id_Frequancy = fre;
                    recommendation.UserId = userid;
                    DB.Recommendation_Advs.Add(recommendation);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        public ActionResult DeleteAdv(int id)
        {
            int _id = int.Parse(Session["id_nozom"].ToString());
            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                var adv = DB.Recommendation_Advs.FirstOrDefault(w => w.ID == id);
                if (adv != null)
                {
                    DB.Recommendation_Advs.Remove(adv);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        #endregion


        #region bianat 7rga
        public ActionResult GetCritData(int id)
        {
            try
            {
                ViewBag.crtdta = new SelectList(DB.Critical_Datas.ToList(), "ID", "Critic_Data");
                ViewBag.crt2 = DB.Critical_Datas.ToList();
                ViewBag.crt = DB.Crit_Datas.Where(w => w.Id_Nozom == id).ToList();
                return PartialView(DB.Crit_Datas.FirstOrDefault(w => w.Id_Nozom == id));

            }
            catch (Exception)
            {
                return PartialView(DB.Crit_Datas.FirstOrDefault(w => w.Id_Nozom == id));
            }
        }

        [HttpPost]
        public ActionResult CrtData(Crit_Data crit)
        {
            int userid = int.Parse(Session["UserId"].ToString());
            int _id = int.Parse(Session["id_nozom"].ToString());
            var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
            var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
            try
            {
                var crt = DB.Crit_Datas.Where(w => w.Id_Nozom == _id && w.Id_Frequancy == fre).FirstOrDefault(w => w.Id_CriticalData == crit.Id_CriticalData);
                if (crt == null)
                {
                    crit.Date = DateTime.Now;
                    crit.Id_Nozom = _id;
                    crit.Id_Frequancy = fre;
                    crit.UserId = userid;
                    DB.Crit_Datas.Add(crit);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });
            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        public ActionResult DeleteCrt(int id)
        {
            int _id = int.Parse(Session["id_nozom"].ToString());
            try
            {
                var crt = DB.Crit_Datas.FirstOrDefault(w => w.ID == id);
                if (crt != null)
                {
                    DB.Crit_Datas.Remove(crt);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        #endregion


        #region ta45is
        public ActionResult GetDiag(int id)
        {
            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                ViewBag.dig = DB.Diagnosis.Where(w => w.Id_Nozom == id && w.Id_Frequancy == fre).ToList();
                return PartialView(DB.Diagnosis.FirstOrDefault(w => w.Id_Nozom == id && w.Id_Frequancy == fre));
            }
            catch (Exception)
            {
                return PartialView(DB.Diagnosis.FirstOrDefault(w => w.Id_Nozom == id));
            }
        }

        [HttpPost]
        public ActionResult Diag(Diagnosis diagnosis)
        {
            int _id = int.Parse(Session["id_nozom"].ToString());
            try
            {
                int userid = int.Parse(Session["UserId"].ToString());
                var emp = DB.Employees.Where(w => w.ID == userid).FirstOrDefault();
                var fre = DB.Clinic_Registers.Where(w => w.Id_patient == _id && w.DepartmentId == emp.Department_ID).OrderByDescending(w => w.ID).FirstOrDefault().ID_Frequancy;
                var dig = DB.Diagnosis.Where(w => w.Id_Nozom == _id && w.Id_Frequancy == fre).FirstOrDefault(w => w._Diagnosis == diagnosis._Diagnosis);
                if (dig == null)
                {
                    diagnosis.Date = DateTime.Now;
                    diagnosis.Id_Nozom = _id;
                    diagnosis.Id_Frequancy = fre;
                    diagnosis.UserId = userid;
                    DB.Diagnosis.Add(diagnosis);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        public ActionResult DeleteDig(int id)
        {
            int _id = int.Parse(Session["id_nozom"].ToString());
            try
            {
                var dig = DB.Diagnosis.FirstOrDefault(w => w.ID == id);
                if (dig != null)
                {
                    DB.Diagnosis.Remove(dig);
                    DB.SaveChanges();
                }
                return RedirectToAction("patient", new { id = _id });

            }
            catch (Exception)
            {
                return RedirectToAction("patient", new { id = _id });
            }
        }
        #endregion
    }
}