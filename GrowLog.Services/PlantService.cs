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
            byte[] bytes = null;
            if(model.File != null)
            {
                Stream image = model.File.InputStream;
                BinaryReader br = new BinaryReader(image);
                bytes = br.ReadBytes((Int32)image.Length);
            }


            var entity =
                new Plant()
                {
                    OwnerId = _userId,
                    PlantName = model.PlantName,
                    Description = model.Description,
                    HarvestSeasonStart = model.HarvestSeasonStart,
                    HarvestSeasonEnd = model.HarvestSeasonEnd,
                    PlantingSeasonStart = model.PlantingSeasonStart,
                    PlantingSeasonEnd = model.PlantingSeasonEnd,
                    TypeOfPlantCategory = model.TypeOfPlantCategory,
                    LocationID = model.LocationID,
                    FileContent = bytes,
                    File = model.File,
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
                                LocationName = e.Location.Name
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
                        HarvestSeasonStart = entity.HarvestSeasonStart,
                        HarvestSeasonEnd = entity.HarvestSeasonEnd,
                        PlantingSeasonStart = entity.PlantingSeasonStart,
                        PlantingSeasonEnd = entity.PlantingSeasonEnd,
                        TypeOfPlantCategory = entity.TypeOfPlantCategory,
                        LocationID = entity.LocationID,
                        LocationName = entity.Location.Name,
                        FileContent = entity.FileContent,
                        File = entity.File,
                    };
            }
        }

        public bool UpdatePlant(PlantDetail model)
        {
            byte[] bytes = model.FileContent;
            if (model.File != null)
            { 
                Stream image = model.File.InputStream;
                BinaryReader br = new BinaryReader(image);
                bytes = br.ReadBytes((Int32)image.Length);
            }

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plants
                        .Single(e => e.PlantID == model.PlantID && e.OwnerId == _userId);

                entity.OwnerId = _userId;
                entity.PlantName = model.PlantName;
                entity.Description = model.Description;
                entity.HarvestSeasonStart = model.HarvestSeasonStart;
                entity.HarvestSeasonEnd = model.HarvestSeasonEnd;
                entity.PlantingSeasonStart = model.PlantingSeasonStart;
                entity.PlantingSeasonEnd = model.PlantingSeasonEnd;
                entity.TypeOfPlantCategory = model.TypeOfPlantCategory;
                entity.LocationID = model.LocationID;
                entity.FileContent = model.FileContent;
                entity.File = model.File;

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
