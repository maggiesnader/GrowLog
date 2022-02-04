using GrowLog.Data;
using GrowLog.Models;
using GrowLogWebMVC.Data;
using System;
using System.Collections.Generic;
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
            _userId = userId
;        }

        public bool CreatePlant(PlantCreate model)
        {
            var entity =
                new Plant()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    HarvestSeasonStart = model.HarvestSeasonStart,
                    HarvestSeasonEnd = model.HarvestSeasonEnd,
                    PlantingSeasonStart = model.PlantingSeasonStart,
                    PlantingSeasonEnd = model.PlantingSeasonEnd,
                    TypeOfPlantCategory = model.TypeOfPlantCategory,
                    LocationID = model.LocationID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plants.Add(entity);
                return ctx.SaveChanges() == 1;
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
                                ID = e.ID,
                                Name = e.Name,
                                TypeOfPlantCategory = e.TypeOfPlantCategory
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
                        .Single(e => e.ID == id && e.OwnerId == _userId);
                return
                    new PlantDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Description = entity.Description,
                        HarvestSeasonStart = entity.HarvestSeasonStart,
                        HarvestSeasonEnd = entity.HarvestSeasonEnd,
                        PlantingSeasonStart = entity.PlantingSeasonStart,
                        PlantingSeasonEnd = entity.PlantingSeasonEnd,
                        TypeOfPlantCategory = entity.TypeOfPlantCategory,
                        LocationID = entity.LocationID
                    };
            }
        }








    }
}
