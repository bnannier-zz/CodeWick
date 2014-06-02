using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Areas.Account.Models;
using CodeWick.Helpers;
using CodeWick.Models;

namespace CodeWick.Areas.Account.Controllers {
    [HandleError]
    [SessionAttribute]
    public class LoginController : Controller {
        // GET: /Account/Login
        public ActionResult Index() {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Index(LoginModel model, string returnUrl) {
            if (ModelState.IsValid) {
                //MembershipChangeLater
                ASPNET_Membership.WebSecurity.MembershipLoginStatus status = ASPNET_Membership.WebSecurity.Login(model.UserName, model.Password, model.RememberMe);
                if (status == ASPNET_Membership.WebSecurity.MembershipLoginStatus.Success) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")) {
                        return Redirect(returnUrl);
                    } else {
                        return RedirectToAction("Index", "Site");
                    }
                } else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}