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
    public class AreasController : Controller {
		private readonly IAreaRepository areaRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public AreasController() : this(new AreaRepository()){}

        public AreasController(IAreaRepository areaRepository){
			this.areaRepository = areaRepository;
        }

        // GET: /Areas/
        public ViewResult Index(){
            return View(areaRepository.All);
        }

        // GET: /Areas/Details/5
        public ViewResult Details(long id)
        {
            return View(areaRepository.Find(id));
        }

        // GET: /Areas/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Areas/Create
        [HttpPost]
        public ActionResult Create(Area area)
        {
            if (ModelState.IsValid) {
                areaRepository.InsertOrUpdate(area);
                areaRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Areas/Edit/5
        public ActionResult Edit(long id)
        {
             return View(areaRepository.Find(id));
        }

        // POST: /Areas/Edit/5
        [HttpPost]
        public ActionResult Edit(Area area){
            if (ModelState.IsValid) {
                areaRepository.InsertOrUpdate(area);
                areaRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        // GET: /Areas/Delete/5
        public ActionResult Delete(long id){
            return View(areaRepository.Find(id));
        }

        // POST: /Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id){
            areaRepository.Delete(id);
            areaRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

