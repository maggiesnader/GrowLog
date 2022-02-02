using GrowLog.Models;
using GrowLog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrowLogWebMVC.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var service = CreateLocationService();

            var model = service.GetLocations();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Location could not be created.");

            return View(model);
        }

        // GET
        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);

            return View(model);
        }

        // GET
        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model =
                new LocationDetail
                {
                    ID = detail.ID,
                    Name = detail.Name,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your Location was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Location could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLocationService();

            service.DeleteLocation(id);

            TempData["SaveResult"] = "Your Location was deleted.";

            return RedirectToAction("Index");
        }




        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }
    }
}