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
    public class SettingsController : Controller {
		private readonly IThemeRepository themeRepository;
		private readonly ISettingRepository settingRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public SettingsController() : this(new ThemeRepository(), new SettingRepository()){}

        public SettingsController(IThemeRepository themeRepository, ISettingRepository settingRepository){
			this.themeRepository = themeRepository;
			this.settingRepository = settingRepository;
        }

        // GET: /Settings/
        public ViewResult Index(){
            return View(settingRepository.AllIncluding(setting => setting.Theme));
        }

        // GET: /Settings/Details/5
        public ViewResult Details(long id)
        {
            return View(settingRepository.Find(id));
        }

        // GET: /Settings/Create
        public ActionResult Create()
        {
			ViewBag.PossibleThemes = themeRepository.All;
            return View();
        } 

        // POST: /Settings/Create
        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid) {
                settingRepository.InsertOrUpdate(setting);
                settingRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleThemes = themeRepository.All;
				return View();
			}
        }

        // GET: /Settings/Edit/5
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleThemes = themeRepository.All;
             return View(settingRepository.Find(id));
        }

        // POST: /Settings/Edit/5
        [HttpPost]
        public ActionResult Edit(Setting setting){
            if (ModelState.IsValid) {
                settingRepository.InsertOrUpdate(setting);
                settingRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleThemes = themeRepository.All;
				return View();
			}
        }

        // GET: /Settings/Delete/5
        public ActionResult Delete(long id){
            return View(settingRepository.Find(id));
        }

        // POST: /Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            settingRepository.Delete(id);
            settingRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

