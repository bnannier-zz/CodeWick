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
    public class LogMessagesController : Controller {
		private readonly ILogMessageRepository logmessageRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public LogMessagesController() : this(new LogMessageRepository()){}

        public LogMessagesController(ILogMessageRepository logmessageRepository){
			this.logmessageRepository = logmessageRepository;
        }

        // GET: /LogMessages/
        public ViewResult Index(){
            return View(logmessageRepository.All);
        }

        // GET: /LogMessages/Details/5
        public ViewResult Details(long id)
        {
            return View(logmessageRepository.Find(id));
        }

        // GET: /LogMessages/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /LogMessages/Create
        [HttpPost]
        public ActionResult Create(LogMessage logmessage)
        {
            if (ModelState.IsValid) {
                logmessageRepository.InsertOrUpdate(logmessage);
                logmessageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /LogMessages/Edit/5
        public ActionResult Edit(long id)
        {
             return View(logmessageRepository.Find(id));
        }

        // POST: /LogMessages/Edit/5
        [HttpPost]
        public ActionResult Edit(LogMessage logmessage){
            if (ModelState.IsValid) {
                logmessageRepository.InsertOrUpdate(logmessage);
                logmessageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /LogMessages/Delete/5
        public ActionResult Delete(long id){
            return View(logmessageRepository.Find(id));
        }

        // POST: /LogMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            logmessageRepository.Delete(id);
            logmessageRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

