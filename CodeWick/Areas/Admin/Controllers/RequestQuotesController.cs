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
    public class RequestQuotesController : Controller {
		private readonly IRequestQuoteRepository requestquoteRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public RequestQuotesController() : this(new RequestQuoteRepository()){}

        public RequestQuotesController(IRequestQuoteRepository requestquoteRepository){
			this.requestquoteRepository = requestquoteRepository;
        }

        // GET: /RequestQuotes/
        public ViewResult Index(){
            return View(requestquoteRepository.All);
        }

        // GET: /RequestQuotes/Details/5
        public ViewResult Details(long id)
        {
            return View(requestquoteRepository.Find(id));
        }

        // GET: /RequestQuotes/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /RequestQuotes/Create
        [HttpPost]
        public ActionResult Create(RequestQuote requestquote)
        {
            if (ModelState.IsValid) {
                requestquoteRepository.InsertOrUpdate(requestquote);
                requestquoteRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /RequestQuotes/Edit/5
        public ActionResult Edit(long id)
        {
             return View(requestquoteRepository.Find(id));
        }

        // POST: /RequestQuotes/Edit/5
        [HttpPost]
        public ActionResult Edit(RequestQuote requestquote){
            if (ModelState.IsValid) {
                requestquoteRepository.InsertOrUpdate(requestquote);
                requestquoteRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /RequestQuotes/Delete/5
        public ActionResult Delete(long id){
            return View(requestquoteRepository.Find(id));
        }

        // POST: /RequestQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            requestquoteRepository.Delete(id);
            requestquoteRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

