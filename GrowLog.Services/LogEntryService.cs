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
    public class LogEntryService
    {
        private readonly Guid _userId;

        public LogEntryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLogEntry(LogEntryCreate model)
        {
            var entity =
                new LogEntry()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    PlantID = model.PlantID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LogEntries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LogEntryListItem> GetLogEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .LogEntries
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new LogEntryListItem
                        {
                            LogEntryID = e.LogEntryID,
                            Name = e.Name,
                            DateCreated = e.DateCreated,
                            PlantID = e.PlantID
                        });
                return query.ToArray();
            }
        }

        public LogEntryDetail GetLogEntriesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LogEntries
                        .Single(e => e.LogEntryID == id && e.OwnerId == _userId);
                return
                    new LogEntryDetail
                    {
                        LogEntryID = entity.LogEntryID,
                        Name = entity.Name,
                        Description = entity.Description,
                        DateCreated = entity.DateCreated,
                        PlantID = entity.PlantID
                    };
            }
        }

        public bool UpdateLogEntry(LogEntryDetail model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LogEntries
                        .Single(e => e.LogEntryID == model.LogEntryID && e.OwnerId == _userId);
                entity.OwnerId = _userId;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.DateCreated = model.DateCreated;
                entity.PlantID = model.PlantID;

                return ctx.SaveChanges() == 1;
            }
        }
       
        public bool DeleteLogEntry(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LogEntries
                        .Single(e => e.LogEntryID == id && e.OwnerId == _userId);
                ctx.LogEntries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
