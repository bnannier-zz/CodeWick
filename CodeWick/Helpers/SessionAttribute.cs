using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Models;

namespace CodeWick.Helpers {
    public class SessionAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    Setting setting = context.Settings.Single();
                    SessionHelper sh = new SessionHelper();

                    if (sh.SessionSettingSet()) { // Set Settings in to Session
                        sh.SessionThemeSet(setting.ThemeId); // Set Themes in to Session
                        sh.SessionUserSet();
                    }
                }
            } catch (Exception ex) { using (LogHelper lh = new LogHelper()) lh.LogException(ex); }

            base.OnActionExecuting(filterContext);
        }
    }
}