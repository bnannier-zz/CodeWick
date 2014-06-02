using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Models;
using CodeWick.Areas.Account.Models;
using CodeWick.Helpers;

namespace CodeWick.Controllers {
    [HandleError]
    public class ModulesController : Controller {
        #region _Navigation
        [ChildActionOnly]
        public ActionResult _Navigation(string id = "") {
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    // Check SEOURL for match in Categories first
                    Category Category = context.Categories.FirstOrDefault(tbl => tbl.SEOURL == id);

                    // Match not found
                    if (Category != null) {
                        ViewBag.NavLinks = BuildCategory(FindParentCategory(Category));
                    } else { // Check SEOURL for match in Content
                        Content Content = context.Contents.FirstOrDefault(tbl => tbl.SEOURL == id);
                        Category = context.Categories.FirstOrDefault(tbl => tbl.CategoryId == Content.CategoryId);
                        ViewBag.NavLinks = BuildCategory(FindParentCategory(Category));
                    }
                }
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return PartialView();
        }

        public Category FindParentCategory(Category Category) {
            Category rtn = new Category();
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    if (Category.ParentId.HasValue) {
                        Category Parent = context.Categories.FirstOrDefault(tbl => tbl.CategoryId == Category.ParentId);

                        if (Parent != null)
                            rtn = FindParentCategory(Parent);
                    } else {
                        rtn = Category;
                    }
                }
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return rtn;
        }

        public string BuildCategory(Category Category) {
            string navLinks = "";
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    List<Category> Categories = context.Categories.Where(tbl => tbl.ParentId == Category.CategoryId).OrderBy(tbl => tbl.Title).ToList();

                    foreach (Category category in Categories) {
                        navLinks += "<ul><li><a href=\"" + Request.ApplicationPath + "Site/Category/" + category.SEOURL + "\">" + category.Title + "</a>";
                        navLinks += BuildCategory(category);
                        navLinks += "</li></ul>";
                    }
                }

                navLinks += BuildContent(Category);
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return navLinks;
        }

        public string BuildContent(Category Category) {
            string navLinks = "";
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    List<Content> Contents = context.Contents.Where(tbl => tbl.CategoryId == Category.CategoryId).OrderBy(tbl => tbl.Title).ToList();

                    foreach (Content Content in Contents) {
                        navLinks += "<ul><li><a href=\"" + Request.ApplicationPath + "Site/Content/" + Content.SEOURL + "\">" + Content.Title + "</a></li></ul>";
                    }
                }
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return navLinks;
        }
        #endregion

        #region _RequestQuote
        [ChildActionOnly]
        public ActionResult _RequestQuote() {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _RequestQuote(RequestQuote model) {
            return View();
        }
        #endregion

        #region _Login
        [ChildActionOnly]
        public ActionResult _Login() {
            LoginModel model = new LoginModel();
            model.IsAuthenticated = false;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult _Login(LoginModel model, string returnUrl) {
            if (ModelState.IsValid) {
                ASPNET_Membership.WebSecurity.MembershipLoginStatus status = ASPNET_Membership.WebSecurity.Login(model.UserName, model.Password, model.RememberMe);
                if (status == ASPNET_Membership.WebSecurity.MembershipLoginStatus.Success) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    model.IsAuthenticated = true;
                } else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return PartialView(model);
        }
        #endregion

        #region _Content
        [ChildActionOnly]
        public ActionResult _Content(string id) {
            Content content = new Content(); 
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    content = context.Contents.FirstOrDefault(tbl => tbl.SEOURL.ToLower() == id.ToLower());
                }
            } catch (Exception ex) {
                LogHelper log = new LogHelper();
                log.LogException(ex);
            }
            return PartialView(content);
        }
        #endregion

        #region _NewsTicker
        [ChildActionOnly]
        public ActionResult _NewsTicker() {
            List<Content> content = new List<Content>();
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                   // content = context.Contents.Where(tbl => tbl.NewsTicker == true).OrderBy(tbl => tbl.NewsTickerOrder).ToList();
                }
            } catch (Exception ex) {
                LogHelper log = new LogHelper();
                log.LogException(ex);
            }
            return PartialView(content);
        }
        #endregion
    }
}