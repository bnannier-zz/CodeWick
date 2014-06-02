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
    public class RegisterController : Controller {
        // GET: /Account/Register
        public ActionResult Index() {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [CaptchaValidator]
        public ActionResult Index(RegisterModel model, bool captchaValid) {
            if (captchaValid) {
                if (ModelState.IsValid) {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus = new MembershipCreateStatus();
                    createStatus = ASPNET_Membership.WebSecurity.Register(model.UserName, model.Password, model.Email, true, null, null);

                    if (createStatus == MembershipCreateStatus.Success) {
                        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                        return RedirectToAction("Index", "../Site");
                    } else {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
            } else {
                ModelState.AddModelError("", "Words in reCaptcha doesn’t match.");
                return View(model);
            }

            //MembershipChangeLater
            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = Membership.MinRequiredPasswordLength;
            return View(model);
        }

        // Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}