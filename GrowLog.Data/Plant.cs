using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GrowLog.Data
{
    public class Plant : IPicture
    {
        [Key]
        [DHXJson(Alias = "id")]
        public int PlantID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [DHXJson(Alias = "text")]
        public string PlantName { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Start of Planting Season")]
        [DataType(DataType.Date)]
        [DHXJson(Alias = "start_date")]
        public DateTime? PlantingSeasonStart { get; set; }

        [Display(Name = "End of Planting Season")]
        [DataType(DataType.Date)]
        [DHXJson(Alias = "end_date")]
        public DateTime? PlantingSeasonEnd { get; set; }

        [Required]
        [Display(Name = "Type Of Plant")]
        public PlantCategory TypeOfPlantCategory { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        [Display(Name = "Location")]
        public string LocationName { get; set; }

        [DHXJson(Ignore = true)]
        public List<LogEntry> LogEntries { get; set; }

        //public byte[] FileContent { get; set; }

        //[NotMapped]
        ///public HttpPostedFileBase File { get; set; }


        //[Display(Name = "Start of Harvest Season")]
        //[DataType(DataType.Date)]
        //public DateTime? HarvestSeasonStart { get; set; }

        //[Display(Name = "End of Harvest Season")]
        //[DataType(DataType.Date)]
        //public DateTime? HarvestSeasonEnd { get; set; }


    }
}
