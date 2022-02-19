using GrowLog.Models;
using GrowLog.Services;
using GrowLogWebMVC.Data;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrowLogWebMVC.Controllers
{
    [Authorize]
    public class LogEntryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: LogEntry
        public ActionResult Index(int? plantID, int? page) 
        {

            var service = CreateLogEntryService();
            var model = service.GetLogEntries().Where(le => le.PlantID == plantID
           || plantID == null).OrderBy(m => m.DateCreated);

            int Size_Of_Page = 4;
            int No_Of_Page = (page ?? 1);
            return View(model.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.PlantId = new SelectList(_db.Plants, "PlantId", "PlantName");
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogEntryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLogEntryService();

            if (service.CreateLogEntry(model))
            {
                TempData["SaveResult"] = "Your Log Entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Plant could not be created.");

            return View("model");
        }

        //GET
        public ActionResult Details(int id)
        {
            var svc = CreateLogEntryService();
            var model = svc.GetLogEntriesById(id);

            return View(model);
        }

        //GET
        public ActionResult Edit(int id)
        {
            ViewBag.PlantId = new SelectList(_db.Plants, "PlantId", "PlantName");

            var service = CreateLogEntryService();
            var detail = service.GetLogEntriesById(id);
            var model =
                new LogEntryDetail
                {
                    LogEntryID = detail.LogEntryID,
                    Name = detail.Name,
                    Description = detail.Description,
                    DateCreated = detail.DateCreated,
                    PlantID = detail.PlantID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LogEntryDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LogEntryID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLogEntryService();

            if (service.UpdateLogEntry(model))
            {
                TempData["SaveResult"] = "Your Log Entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Log Entry could not be updated.");
            return View(model);
        }

        //GET
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLogEntryService();
            var model = svc.GetLogEntriesById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLogEntryService();

            service.DeleteLogEntry(id);

            TempData["SaveResult"] = "Your Log Entry was deleted.";

            return RedirectToAction("Index");
        }







        private LogEntryService CreateLogEntryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LogEntryService(userId);
            return service;
        }

    }
}