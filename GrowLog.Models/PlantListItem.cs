using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class PlantListItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Type Of Plant")]
        public PlantCategory TypeOfPlantCategory { get; set; }

        [Display(Name = "Location Name")]
        public int LocationID { get; set; }
    }
}
