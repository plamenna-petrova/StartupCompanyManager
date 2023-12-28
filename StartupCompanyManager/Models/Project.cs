﻿using StartupCompanyManager.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; } 

        public DateTime AssignmentDate { get; set; }

        public DateTime Deadline { get; set; }

        public Team Team { get; set; }
    }
}