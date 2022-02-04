using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class PlantListItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public PlantCategory TypeOfPlantCategory { get; set; }


        public int LocID { get; set; }
    }
}
