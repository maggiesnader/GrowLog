﻿using GrowLog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class LogEntryDetail
    {
        [Key]
        public int LogEntryID { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Plant")]
        public int PlantID { get; set; }
        public virtual Plant Plant { get; set; }
    }
}
