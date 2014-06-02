using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Helpers;
using CodeWick.Models;
using CodeWick.Areas.Admin.Models;

namespace CodeWick.Areas.Admin.Controllers{
	[HandleError]
    [SessionAttribute]
    [AdminAuthorize]
    public class ThemesController : Controller {
		private readonly IThemeRepository themeRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ThemesController() : this(new ThemeRepository()){}

        public ThemesController(IThemeRepository themeRepository){
			this.themeRepository = themeRepository;
        }

        // GET: /Themes/
        public ViewResult Index(){
            return View(themeRepository.All);
        }

        // GET: /Themes/Details/5
        public ViewResult Details(long id)
        {
            return View(themeRepository.Find(id));
        }

        // GET: /Themes/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Themes/Create
        [HttpPost]
        public ActionResult Create(Theme theme)
        {
            if (ModelState.IsValid) {
                themeRepository.InsertOrUpdate(theme);
                themeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Themes/Edit/5
        public ActionResult Edit(long id)
        {
             return View(themeRepository.Find(id));
        }

        // POST: /Themes/Edit/5
        [HttpPost]
        public ActionResult Edit(Theme theme){
            if (ModelState.IsValid) {
                themeRepository.InsertOrUpdate(theme);
                themeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Themes/Delete/5
        public ActionResult Delete(long id){
            return View(themeRepository.Find(id));
        }

        // POST: /Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            themeRepository.Delete(id);
            themeRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

