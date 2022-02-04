using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class PlantCreate
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan HarvestSeason { get; set; }

        public TimeSpan PlantingSeason { get; set; }

        public PlantCategory TypeOfPlantCategory { get; set; }

        public int LocID { get; set; }
    }
}
