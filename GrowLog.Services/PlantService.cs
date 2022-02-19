using GrowLog.Data;
using GrowLog.Models;
using GrowLogWebMVC.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Services
{
    public class PlantService
    {
        private readonly Guid _userId;

        public PlantService(Guid userId)
        {
            _userId = userId;
       }

        public bool CreatePlant(PlantCreate model)
        {
            //byte[] bytes = null;
            //if(model.File != null)
            //{
                //Stream image = model.File.InputStream;
                //BinaryReader br = new BinaryReader(image);
                //bytes = br.ReadBytes((Int32)image.Length);
            //}


            var entity =
                new Plant()
                {
                    OwnerId = _userId,
                    PlantName = model.PlantName,
                    Description = model.Description,
                    PlantingSeasonStart = model.PlantingSeasonStart,
                    PlantingSeasonEnd = model.PlantingSeasonEnd,
                    TypeOfPlantCategory = model.TypeOfPlantCategory,
                    LocationID = model.LocationID,

                    //HarvestSeasonStart = model.HarvestSeasonStart,
                    //HarvestSeasonEnd = model.HarvestSeasonEnd,
                    //FileContent = bytes,
                    //File = model.File,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plants.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<PlantListItem> GetPlants()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Plants
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new PlantListItem
                            {
                                PlantID = e.PlantID,
                                PlantName = e.PlantName,
                                TypeOfPlantCategory = e.TypeOfPlantCategory,
                                LocationID = e.LocationID,
                                LocationName = e.Location.Name,
                                PlantingSeasonStart = e.PlantingSeasonStart,
                            }
                            );
                return query.ToArray();
            }
        }

        public PlantDetail GetPlantById(int id)
        {
            
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantID == id && e.OwnerId == _userId);
                return
                    new PlantDetail
                    {
                        OwnerId = _userId,
                        PlantID = entity.PlantID,
                        PlantName = entity.PlantName,
                        Description = entity.Description,
                        PlantingSeasonStart = entity.PlantingSeasonStart,
                        PlantingSeasonEnd = entity.PlantingSeasonEnd,
                        TypeOfPlantCategory = entity.TypeOfPlantCategory,
                        LocationID = entity.LocationID,
                        LocationName = entity.Location.Name,


                        //HarvestSeasonStart = entity.HarvestSeasonStart,
                        //HarvestSeasonEnd = entity.HarvestSeasonEnd,
                        //FileContent = entity.FileContent,
                        //File = entity.File,
                    };
            }
        }

        public bool UpdatePlant(PlantDetail model)
        {
            //byte[] bytes = model.FileContent;
            //if (model.FileContent != null)
            //{ 
             //   Stream image = model.File.InputStream;
             //   BinaryReader br = new BinaryReader(image);
            //    bytes = br.ReadBytes((Int32)image.Length);
            //}

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantID == model.PlantID && e.OwnerId == _userId);

                entity.OwnerId = _userId;
                entity.PlantName = model.PlantName;
                entity.Description = model.Description;
                entity.PlantingSeasonStart = model.PlantingSeasonStart;
                entity.PlantingSeasonEnd = model.PlantingSeasonEnd;
                entity.TypeOfPlantCategory = model.TypeOfPlantCategory;
                entity.LocationID = model.LocationID;

                //entity.HarvestSeasonStart = model.HarvestSeasonStart;
                //entity.HarvestSeasonEnd = model.HarvestSeasonEnd;
                //entity.FileContent = bytes;
                //entity.File = model.File;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeletePlant(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantID == id && e.OwnerId == _userId);
                ctx.Plants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }




    }
}
