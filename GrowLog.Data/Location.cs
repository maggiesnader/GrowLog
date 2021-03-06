using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DHXJson(Ignore = true)]
        public List<Plant> Plants { get; set; }

    }
}
