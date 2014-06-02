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
    public class ViewsController : Controller {
		private readonly IViewRepository viewRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ViewsController() : this(new ViewRepository()){}

        public ViewsController(IViewRepository viewRepository){
			this.viewRepository = viewRepository;
        }

        // GET: /Views/
        public ViewResult Index(){
            return View(viewRepository.All);
        }

        // GET: /Views/Details/5
        public ViewResult Details(long id)
        {
            return View(viewRepository.Find(id));
        }

        // GET: /Views/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Views/Create
        [HttpPost]
        public ActionResult Create(View view)
        {
            if (ModelState.IsValid) {
                viewRepository.InsertOrUpdate(view);
                viewRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Views/Edit/5
        public ActionResult Edit(long id)
        {
             return View(viewRepository.Find(id));
        }

        // POST: /Views/Edit/5
        [HttpPost]
        public ActionResult Edit(View view){
            if (ModelState.IsValid) {
                viewRepository.InsertOrUpdate(view);
                viewRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Views/Delete/5
        public ActionResult Delete(long id){
            return View(viewRepository.Find(id));
        }

        // POST: /Views/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            viewRepository.Delete(id);
            viewRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

