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
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new LocationListItem
                            {
                                LocationID = e.LocationID,
                                Name = e.Name
                            }

                           );

                return query.ToArray();
            }
        }

        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id && e.OwnerId == _userId);
                return
                    new LocationDetail
                    {
                        LocationID = entity.LocationID,
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateLocation(LocationDetail model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id && e.OwnerId == _userId);
                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }





    }
}
