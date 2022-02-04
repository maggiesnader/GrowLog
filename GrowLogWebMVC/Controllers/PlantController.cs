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













        private PlantService CreatePlantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(userId);
            return service;
        }
    }
}