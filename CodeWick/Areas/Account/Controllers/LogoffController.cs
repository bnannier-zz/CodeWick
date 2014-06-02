using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Areas.Account.Models;
using CodeWick.Helpers;

namespace CodeWick.Areas.Account.Controllers {
    [HandleError]
    [SessionAttribute]
    public class LogoffController : Controller {
        // GET: /Account/Logoff/
        public ActionResult Index() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Site");
        }
    }
}