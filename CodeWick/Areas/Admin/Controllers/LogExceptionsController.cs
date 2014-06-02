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
    public class LogExceptionsController : Controller {
		private readonly ILogExceptionRepository logexceptionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public LogExceptionsController() : this(new LogExceptionRepository()){}

        public LogExceptionsController(ILogExceptionRepository logexceptionRepository){
			this.logexceptionRepository = logexceptionRepository;
        }

        // GET: /LogExceptions/
        public ViewResult Index(){
            return View(logexceptionRepository.All);
        }

        // GET: /LogExceptions/Details/5
        public ViewResult Details(long id)
        {
            return View(logexceptionRepository.Find(id));
        }

        // GET: /LogExceptions/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /LogExceptions/Create
        [HttpPost]
        public ActionResult Create(LogException logexception)
        {
            if (ModelState.IsValid) {
                logexceptionRepository.InsertOrUpdate(logexception);
                logexceptionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /LogExceptions/Edit/5
        public ActionResult Edit(long id)
        {
             return View(logexceptionRepository.Find(id));
        }

        // POST: /LogExceptions/Edit/5
        [HttpPost]
        public ActionResult Edit(LogException logexception){
            if (ModelState.IsValid) {
                logexceptionRepository.InsertOrUpdate(logexception);
                logexceptionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /LogExceptions/Delete/5
        public ActionResult Delete(long id){
            return View(logexceptionRepository.Find(id));
        }

        // POST: /LogExceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            logexceptionRepository.Delete(id);
            logexceptionRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

