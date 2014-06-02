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
    public class PasswordController : Controller {
        // GET: /Account/Password/Change
        [Authorize]
        public ActionResult Change() {
            return View();
        }

        // POST: /Account/Password/Change
        [Authorize]
        [HttpPost]
        public ActionResult Change(PasswordModel model) {
            if (ModelState.IsValid) {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                ////bool changePasswordSucceeded;
                try {
                    //MembershipChangeLater
                    ////MembershipUser currentUser = ASPNET_Membership.WebSecurity.GetUser(User.Identity.Name);
                    ////changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                } catch (Exception) {
                    ////changePasswordSucceeded = false;
                }

                //MembershipChangeLater
                ////if (changePasswordSucceeded) {
                ////    return RedirectToAction("ChangePasswordSuccess");
                ////} else {
                ////    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                ////}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/Password/ChangeSuccess
        public ActionResult ChangeSuccess() {
            return View();
        }
    }
}