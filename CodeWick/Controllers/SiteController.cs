using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CodeWick.Models;
using CodeWick.Helpers;

namespace CodeWick.Controllers {
    [HandleError]
    [SessionAttribute]
    public class SiteController : Controller {
        // GET: /Site/
        public ActionResult Index() {
            return View();
        }

        // GET: /Site/Category
        public ActionResult Category(string id = "") {
            Category Category = new Category();
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    Category = context.Categories.First(tbl => tbl.SEOURL == id);
                }
            } catch (Exception ex) {
                LogHelper log = new LogHelper();
                log.LogException(ex);
            }

            return View(Category);
        }

        // GET: /Site/Content
        public virtual new ActionResult Content(string id = "") {
            Content content = new Content();
            try {
                using (CodeWickContext context = new CodeWickContext()) {
                    content = context.Contents.First(tbl => tbl.SEOURL == id);
                }
            } catch (Exception ex) {
                LogHelper log = new LogHelper();
                log.LogException(ex);
            }

            return View(content);
        }
    }
}