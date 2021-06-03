using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS_ITI.Models.ViewModel
{
    public static class Settings
    {
        static HospitalContext db = new HospitalContext();

        static int a = 0;
        static Role_ActionName r = new Role_ActionName();

        public static string UserName = "";
        public static int RoleId = 0;
        public static int UserId = 0;
        public static int registerid = 0;
        public static bool check(string _actionname)
        {
            //var actionid = db.ActionsName.Where(ac => ac.ActionName == _actionname).Select(ac => ac.ID).FirstOrDefault();
            //var r = db.Role_ActionName.Where(ac => ac.RoleId == RoleId && ac.ActionNameId == actionid).FirstOrDefault();
            //if (a == 0)
            //{
                a = db.ActionsNames.Where(ac => ac.ActionName == _actionname).Select(ac => ac.ID).FirstOrDefault();
            //}
            r = db.Role_ActionNames.Where(ac => ac.RoleId == RoleId && ac.ActionNameId == a).FirstOrDefault();

            if (r != null)
                return true;

            return false;
        }
        public static bool checkadmin()
        {
            if (Settings.RoleId == 1)
                return true;

            return false;
        }
    }
}