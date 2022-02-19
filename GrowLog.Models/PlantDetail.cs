using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GrowLog.Models
{
    public class PlantDetail
    {
        
        public int PlantID { get; set; }

        public Guid OwnerId { get; set; }

        [Display(Name = "Name")]
        public string PlantName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start of Planting Season")]
        [DataType(DataType.Date)]
        public DateTime? PlantingSeasonStart { get; set; }

        [Display(Name = "End of Planting Season")]
        [DataType(DataType.Date)]
        public DateTime? PlantingSeasonEnd { get; set; }

        [Display(Name = "Type Of Plant")]
        public PlantCategory TypeOfPlantCategory { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }




        //[Display(Name = "Start of Harvest Season")]
        //[DataType(DataType.Date)]
        //public DateTime? HarvestSeasonStart { get; set; }

        //[Display(Name = "End of Harvest Season")]
        //[DataType(DataType.Date)]
        //public DateTime? HarvestSeasonEnd { get; set; }

        //[Display(Name = "Image")]
        //public byte[] FileContent { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase File { get; set; }

    }
}
