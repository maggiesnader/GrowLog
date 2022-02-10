﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowLog.Models
{
    public class LocationDetail
    {
        public int LocationID { get; set; }
        public Guid OwnerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
