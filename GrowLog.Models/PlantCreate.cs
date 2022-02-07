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

        [Display(Name = "Start of Harvest Season")]
        [DataType(DataType.Date)]
        public DateTime? HarvestSeasonStart { get; set; }

        [Display(Name = "End of Harvest Season")]
        [DataType(DataType.Date)]
        public DateTime? HarvestSeasonEnd { get; set; }


        [Display(Name = "Start of Planting Season")]
        [DataType(DataType.Date)]
        public DateTime? PlantingSeasonStart { get; set; }

        [Display(Name = "End of Planting Season")]
        [DataType(DataType.Date)]
        public DateTime? PlantingSeasonEnd { get; set; }

        [Display(Name = "Type Of Plant")]
        public PlantCategory TypeOfPlantCategory { get; set; }

        [Display(Name = "Location Name")]
        public int LocationID { get; set; }
    }
}
