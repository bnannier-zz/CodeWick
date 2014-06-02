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
    public class RecoverController : Controller {
        // GET: /Account/Recover
        public ActionResult Index() {
            return View();
        }

        // POST: /Account/Recover
        [HttpPost]
        public ActionResult Index(RecoverModel model) {
            try {
                //MembershipChangeLater
                ////List<MembershipUser> membershipUsers = ASPNET_Membership.WebSecurity.FindUsersByEmail(model.UserName_Email, 1, 10);

                ////if (membershipUsers.Count > 0) {
                ////    foreach (MembershipUser membershipUser in membershipUsers) {
                ////        EmailHelper emailHelper = new EmailHelper();
                ////        emailHelper.Send(membershipUser.Email, membershipUser.ResetPassword());
                ////    }
                ////} else {
                ////    membershipUsers = ASPNET_Membership.WebSecurity.FindUsersByName(model.UserName_Email, 1, 10);

                ////    if (membershipUsers.Count > 0) {
                ////        foreach (MembershipUser membershipUser in membershipUsers) {
                ////            EmailHelper emailHelper = new EmailHelper();
                ////            emailHelper.Send(membershipUser.Email, membershipUser.ResetPassword());
                ////        }
                ////    }
                ////}
            } catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
    }
}