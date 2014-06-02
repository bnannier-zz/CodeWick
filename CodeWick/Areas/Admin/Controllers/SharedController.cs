using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Models;
using CodeWick.Areas.Account.Models;
using CodeWick.Helpers;

namespace CodeWick.Areas.Admin.Controllers {
    [HandleError]
    [SessionAttribute]
    public class SharedController : Controller {
        #region _Navigation
        [ChildActionOnly]
        public ActionResult _Navigation() {
            return PartialView();
        }
        #endregion
    }
}