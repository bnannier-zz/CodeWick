using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Helpers;
using CodeWick.Models;
using CodeWick.Repository;

namespace CodeWick.Areas.Admin.Controllers {
    [HandleError]
    [SessionAttribute]
    [AdminAuthorize]
    public class ZonesController : Controller {
        private readonly IAreaRepository areaRepository;
        private readonly IViewRepository viewRepository;
        private readonly IZoneRepository zoneRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ZonesController() : this(new AreaRepository(), new ViewRepository(), new ZoneRepository()) { }

        public ZonesController(IAreaRepository areaRepository, IViewRepository viewRepository, IZoneRepository zoneRepository) {
            this.areaRepository = areaRepository;
            this.viewRepository = viewRepository;
            this.zoneRepository = zoneRepository;
        }

        // GET: /Zones/
        public ViewResult Index() {
            return View(zoneRepository.AllIncluding(zone => zone.Area, zone => zone.View));
        }

        // GET: /Zones/Details/5
        public ViewResult Details(long id) {
            return View(zoneRepository.Find(id));
        }

        // GET: /Zones/Create
        public ActionResult Create() {
            ViewBag.PossibleAreas = areaRepository.All;
            ViewBag.PossibleViews = viewRepository.All;
            return View();
        }

        // POST: /Zones/Create
        [HttpPost]
        public ActionResult Create(Zone zone) {
            if (ModelState.IsValid) {
                zoneRepository.InsertOrUpdate(zone);
                zoneRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.PossibleAreas = areaRepository.All;
                ViewBag.PossibleViews = viewRepository.All;
                return View();
            }
        }

        // GET: /Zones/Edit/5
        public ActionResult Edit(long id) {
            ViewBag.PossibleAreas = areaRepository.All;
            ViewBag.PossibleViews = viewRepository.All;
            return View(zoneRepository.Find(id));
        }

        // POST: /Zones/Edit/5
        [HttpPost]
        public ActionResult Edit(Zone zone) {
            if (ModelState.IsValid) {
                zoneRepository.InsertOrUpdate(zone);
                zoneRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.PossibleAreas = areaRepository.All;
                ViewBag.PossibleViews = viewRepository.All;
                return View();
            }
        }

        // GET: /Zones/Delete/5
        public ActionResult Delete(long id) {
            return View(zoneRepository.Find(id));
        }

        // POST: /Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id) {
            zoneRepository.Delete(id);
            zoneRepository.Save();

            return RedirectToAction("Index");
        }
    }
}