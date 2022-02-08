using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Data
{
    public class Plant
    {
        [Key]
        public int PlantID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string PlantName { get; set; }

        [Required]
        public string Description { get; set; }




        public string FileName { get; set; }

        public byte[] FileContent { get; set; }




        
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

        [Required]
        [Display(Name = "Type Of Plant")]
        public PlantCategory TypeOfPlantCategory { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

    }
}
