using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class PlantDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? HarvestSeason { get; set; }
        public TimeSpan PlantingSeason { get; set; }
        public PlantCategory TypeOfPlantCategory { get; set; }
        public int LocID { get; set; }
    }
}
