using GrowLog.Models;
using GrowLog.Services;
using GrowLogWebMVC.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrowLogWebMVC.Controllers
{
    [Authorize]
    public class PlantController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Plant
        public ActionResult Index()
        {
            var service = CreatePlantService();
            var model = service.GetPlants();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
            return View();
        }

        // POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlantService();

            if (service.CreatePlant(model))
            {
                TempData["SaveResult"] = "Your plant was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Plant could not be created.");

            return View(model);
        }

        // GET
        public ActionResult Details(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);

            return View(model);
        }

        // GET
        public ActionResult Edit(int id)
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");

            var service = CreatePlantService();
            var detail = service.GetPlantById(id);
            var model =
                new PlantDetail
                {
                    PlantID = detail.PlantID,
                    Name = detail.Name,
                    Description = detail.Description,
                    HarvestSeasonStart = detail.HarvestSeasonStart,
                    HarvestSeasonEnd = detail.HarvestSeasonEnd,
                    PlantingSeasonStart = detail.PlantingSeasonStart,
                    PlantingSeasonEnd = detail.PlantingSeasonEnd,
                    TypeOfPlantCategory = detail.TypeOfPlantCategory,
                    LocationID = detail.LocationID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlantDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlantID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlantService();

            if (service.UpdatePlant(model))
            {
                TempData["SaveResult"] = "Your Plant was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Plant could not be updtaed.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlantService();

            service.DeletePlant(id);

            TempData["SaveResult"] = "Your Plant was deleted.";

            return RedirectToAction("Index");
        }




        private PlantService CreatePlantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(userId);
            return service;
        }
    }
}