using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Models;

namespace CodeWick.Helpers {
    public class SessionHelper : System.Web.UI.Page {
        public bool SessionSettingSet() {
            bool rtn = false;
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    Setting setting = context.Settings.First();
                    Session["setting"] = setting;

                    rtn = true;
                }
            } catch (Exception ex) { using (LogHelper lh = new LogHelper()) lh.LogException(ex); }
            return rtn;
        }

        public bool SessionThemeSet(long themeId) {
            bool rtn = false;
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    Theme theme = context.Themes.First(x => x.ThemeId == themeId);
                    Session["theme"] = theme;

                    rtn = true;
                }
            } catch(Exception ex) { using(LogHelper lh = new LogHelper()) lh.LogException(ex); }
            return rtn;
        }

        public bool SessionUserSet() {
            bool rtn = false;
            try {
                // Get User information from database
                Guid userID = new Guid(Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString()); 

                if (userID != null) {
                    using (CodeWickContext context = new CodeWickContext()) {
                        User user = context.Users.First(tbl => tbl.UserId == userID);
                        Session["user"] = user; // Place User information in to session
                        rtn = true;
                    }
                }
                rtn = true;
            } catch(Exception ex) { using(LogHelper lh = new LogHelper()) lh.LogException(ex); }
            return rtn;
        }

        public bool SessionUserRemove() {
            bool rtn = false;
            try {
                Session.Remove("user");
                rtn = true;
            } catch(Exception ex) { using(LogHelper lh = new LogHelper()) lh.LogException(ex); }
            return rtn;
        }
    }
}