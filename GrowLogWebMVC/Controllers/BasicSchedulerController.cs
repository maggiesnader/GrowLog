using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using GrowLog.Data;
using GrowLogWebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrowLogWebMVC.Controllers
{
    public class BasicSchedulerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        // GET: BasicScheduler
        public ActionResult Index()
        {
            var sched = new DHXScheduler(this);
            sched.Skin = DHXScheduler.Skins.Terrace;

            sched.Config.first_hour = 6;
            sched.Config.last_hour = 7;

            //sched.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);

            sched.LoadData = true;
            sched.EnableDataprocessor = true;
            sched.InitialDate = new DateTime(2022, 1, 1);

            return View(sched);
        }

        public ContentResult Data()//DateTime from, DateTime to
        {
            var plants = context.Plants.ToArray();
            return new SchedulerAjaxData(plants);


            //e => e.PlantingSeasonStart < DateTime.Today &&




            //try
            //{
            //var details = context.Plants.ToList();
            //return new SchedulerAjaxData(details);
            //}
            //catch (Exception ex)
            //{
            //throw ex;
            //}


            //return (new SchedulerAjaxData(
            //new ApplicationDbContext().Plants
            //.Select(p => new { p.PlantID, p.PlantName, p.PlantingSeasonStart, p.PlantingSeasonEnd }).ToArray()
            //)
            //);
        }


        public ContentResult Save(int? PlantID, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedPlant = DHXEventsHelper.Bind<Plant>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        context.Plants.Add(changedPlant);
                        break;
                    case DataActionTypes.Delete:
                        context.Entry(changedPlant).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default://"update"
                        context.Entry(changedPlant).State = System.Data.Entity.EntityState.Modified;
                        break;
                }
                context.SaveChanges();
                action.TargetId = changedPlant.PlantID;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));


            //var action = new DataAction(actionValues);

            //try
            //{
                //var changedPlant = (Plant)DHXEventsHelper.Bind(typeof(Plant), actionValues);


                //switch (action.Type)
                //{
                    //case DataActionTypes.Insert:
                        //Plant plant = new Plant();
                        //plant.PlantID = changedPlant.PlantID;
                        //plant.PlantingSeasonStart = changedPlant.PlantingSeasonStart;
                        //plant.PlantingSeasonEnd = changedPlant.PlantingSeasonEnd;
                        //plant.Description = changedPlant.Description;
                        //context.Plants.Add(plant);
                        //context.SaveChanges();

                        //break;

                    //case DataActionTypes.Delete:
                       // var details = context.Plants.Where(x => x.PlantID == PlantID).FirstOrDefault();
                        //context.Plants.Remove(details);
                        //context.SaveChanges();

                        //break;

                    //default:// "update"
                        //var data = context.Plants.Where(x => x.PlantID == PlantID).FirstOrDefault();
                        //data.PlantingSeasonStart = changedPlant.PlantingSeasonStart;
                        //data.PlantingSeasonEnd = changedPlant.PlantingSeasonEnd;
                        //data.Description = changedPlant.Description;
                        //context.SaveChanges();

                        //break;
                //}
            //}
            //catch
            //{
                //action.Type = DataActionTypes.Error;
            //}
            //return (ContentResult)new AjaxSaveResponse(action);

            //var action = new DataAction(actionValues);
            //var changedPlant = DHXEventsHelper.Bind<Plant>(actionValues);
            //var entites = new ApplicationDbContext();
            //try
            //{
            //switch (action.Type)
            //{
            //case DataActionTypes.Insert:
            //entites.Plants.Add(changedPlant);
            //break;
            //case DataActionTypes.Delete:
            //changedPlant = entites.FirstOrDefault(p => p.PlantID == action.SourceId);
            //entites.Plants.Remove(changedPlant);
            //break;
            //default: //update
            //var target = entites.Plants.Single(p => p.PlantID == changedPlant.PlantID);
            //DHXEventsHelper.Update(target, changedPlant, new List<string> { "PlantID" });
            //break;

            //}
            //entites.SaveChanges();
            //action.TargetId = changedPlant.PlantID;
            //}
            //catch (Exception a)
            //{
            //action.Type = DataActionTypes.Error;
            //}

            //return (new AjaxSaveResponse(action));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}