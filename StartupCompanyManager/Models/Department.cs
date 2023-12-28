using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }

        public int YearOfEstablishment { get; set; }

        public HeadOfDepartment HeadOfDepartment { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();    
    }
}
