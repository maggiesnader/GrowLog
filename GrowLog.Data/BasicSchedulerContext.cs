using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Data
{
    public class BasicSchedulerContext : DbContext
    {
        public int id { get; set; }
        public BasicSchedulerContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BasicSchedulerContext>());
        }

    }
}
