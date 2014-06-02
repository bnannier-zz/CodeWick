using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Helpers;
using CodeWick.Models;
using CodeWick.Repository;

namespace CodeWick.Areas.Admin.Controllers{
	[HandleError]
    [SessionAttribute]
    [AdminAuthorize]
    public class ContentsController : Controller {
		private readonly ICategoryRepository categoryRepository;
		private readonly IContentRepository contentRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ContentsController() : this(new CategoryRepository(), new ContentRepository()){}

        public ContentsController(ICategoryRepository categoryRepository, IContentRepository contentRepository){
			this.categoryRepository = categoryRepository;
			this.contentRepository = contentRepository;
        }

        // GET: /Contents/
        public ViewResult Index(){
            return View(contentRepository.AllIncluding(content => content.Category));
        }

        // GET: /Contents/Details/5
        public ViewResult Details(long id)
        {
            return View(contentRepository.Find(id));
        }

        // GET: /Contents/Create
        public ActionResult Create()
        {
			ViewBag.PossibleCategories = categoryRepository.All;
            return View();
        } 

        // POST: /Contents/Create
        [HttpPost]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid) {
                contentRepository.InsertOrUpdate(content);
                contentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCategories = categoryRepository.All;
				return View();
			}
        }

        // GET: /Contents/Edit/5
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleCategories = categoryRepository.All;
             return View(contentRepository.Find(id));
        }

        // POST: /Contents/Edit/5
        [HttpPost]
        public ActionResult Edit(Content content){
            if (ModelState.IsValid) {
                contentRepository.InsertOrUpdate(content);
                contentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCategories = categoryRepository.All;
				return View();
			}
        }

        // GET: /Contents/Delete/5
        public ActionResult Delete(long id){
            return View(contentRepository.Find(id));
        }

        // POST: /Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            contentRepository.Delete(id);
            contentRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

