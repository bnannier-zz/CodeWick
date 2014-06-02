using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Models;

namespace CodeWick.Helpers {
    public class AdminAuthorizeAttribute : AuthorizeAttribute {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            bool rtn = false;
            try {
                if(System.Web.Security.Roles.IsUserInRole("Administrator"))
                    rtn = true;
            } catch (Exception ex) { using (LogHelper lh = new LogHelper()) lh.LogException(ex); }
            return rtn;
        }
    }
}