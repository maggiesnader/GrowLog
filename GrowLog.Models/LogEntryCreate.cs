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
    public class LogEntryCreate
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public int PlantID { get; set; }
        public virtual Plant Plant { get; set; }

    }
}
