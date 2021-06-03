using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS_ITI.Models;
using System.Net;
using HMS_ITI.Models.ViewModel;

namespace HMS_ITI.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        HospitalContext DB = new HospitalContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Settings.check("RoleController_Index") && Session["UserId"] != null)
            {
                return View(DB.Roles.ToList());
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            if (Settings.check("RoleController_AddRole") && Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        public ActionResult AddRole(Role newrole)
        {
            if (ModelState.IsValid)
            {
                //if (DB.Roles.Any(ww => ww.RoleNameAr.Equals(newrole.RoleNameAr)) || DB.Roles.Any(ww => ww.RoleNameEn.Equals(newrole.RoleNameEn)))
                //{
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                try
                {
                    newrole.IsDeleted = false;
                    DB.Roles.Add(newrole);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
                //}
            }
            return RedirectToAction("Index");


        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var role = DB.Roles.Single(ww => ww.ID == id);
        //    return View(role);
        //}

        //[HttpPost]
        //public ActionResult Edit(Role newrole)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var oldrole = DB.Roles.Single(ww => ww.ID == newrole.ID);
        //        oldrole.RoleNameAr = newrole.RoleNameAr;
        //        oldrole.RoleNameEn = newrole.RoleNameEn;
        //        DB.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            var role = DB.Roles.Single(ww => ww.ID == id);
            // role.IsDeleted = true;
            DB.Roles.Remove(role);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (Settings.check("RoleController_Edit") && Session["UserId"] != null)
            {
                List<Role_ActName> lst = new List<Role_ActName>();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = DB.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                var lstactions = DB.ActionsNames.ToList();
                var lstactionsroleids = DB.Role_ActionNames.ToList();
                foreach (var action in lstactions)
                {
                    Role_ActName act = new Role_ActName();
                    act.actionId = action.ID;
                    act.actionName = action.ActionName;
                    act.actionShowName = action.ShowName;
                    for (int i = 0; i < lstactionsroleids.Count; i++)
                    {
                        if (action.ID == lstactionsroleids[i].ActionNameId && lstactionsroleids[i].RoleId == id)
                        {
                            act.Checked = true;
                            break;
                        }
                    }
                    lst.Add(act);
                }
                ViewBag.rolename = role.RoleNameAr;
                TempData["RoleId"] = role.ID;
                return View(lst);
            }
            return RedirectToAction("NotAuthorized", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection coll, List<Role_ActName> R_Action, string RoleName)
        {
            //get value from formcollection
            //var X = coll.AllKeys;
            //var y = X[2];
            if (ModelState.IsValid)
            {
                string id = TempData["RoleId"].ToString();
                Role r = DB.Roles.Find(int.Parse(id));

                var lstactionsroleids = DB.Role_ActionNames.Where(ro => ro.RoleId == r.ID).ToList();
                foreach (var item in lstactionsroleids)
                {
                    DB.Role_ActionNames.Remove(item);
                    DB.SaveChanges();
                }

                var X = coll.AllKeys;
                for (int i = 0; i < coll.Count; i++)
                {
                    Role_ActionName r_Act = new Role_ActionName();
                    r_Act.RoleId = r.ID;
                    try
                    {
                        var y = X[i];
                        int d = int.Parse(y);
                        r_Act.ActionNameId = d;
                        DB.Role_ActionNames.Add(r_Act);
                        DB.SaveChanges();
                    }
                    catch
                    {

                    }
                    var value2 = coll[i];
                }
                r.RoleNameAr = RoleName;
                DB.SaveChanges();
                return RedirectToAction("Index", "Role");
            }

            return View();
        }

    }
}