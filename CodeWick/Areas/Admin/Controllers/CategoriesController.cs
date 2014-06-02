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
    public class CategoriesController : Controller {
		private readonly ICategoryRepository categoryRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CategoriesController() : this(new CategoryRepository()){}

        public CategoriesController(ICategoryRepository categoryRepository){
			this.categoryRepository = categoryRepository;
        }

        // GET: /Categories/
        public ViewResult Index(){
            return View(categoryRepository.AllIncluding(category => category.Parent));
        }

        // GET: /Categories/Details/5
        public ViewResult Details(long id)
        {
            return View(categoryRepository.Find(id));
        }

        // GET: /Categories/Create
        public ActionResult Create()
        {
			ViewBag.PossibleParents = categoryRepository.All;
            return View();
        } 

        // POST: /Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid) {
                categoryRepository.InsertOrUpdate(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleParents = categoryRepository.All;
				return View();
			}
        }

        // GET: /Categories/Edit/5
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleParents = categoryRepository.All;
             return View(categoryRepository.Find(id));
        }

        // POST: /Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category){
            if (ModelState.IsValid) {
                categoryRepository.InsertOrUpdate(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleParents = categoryRepository.All;
				return View();
			}
        }

        // GET: /Categories/Delete/5
        public ActionResult Delete(long id){
            return View(categoryRepository.Find(id));
        }

        // POST: /Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            categoryRepository.Delete(id);
            categoryRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

