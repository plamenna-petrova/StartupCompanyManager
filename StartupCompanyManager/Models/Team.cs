using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;

namespace StartupCompanyManager.Models
{
    public class Team : BaseModel
    {
        public string Name { get; set; }

        public Project Project { get; set; }

        public Department Department { get; set; }

        public TeamLead TeamLead { get; set; }
    }
}
