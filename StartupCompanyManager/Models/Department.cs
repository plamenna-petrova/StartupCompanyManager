using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;

        public int YearOfEstablishment { get; set; }

        public HeadOfDepartment HeadOfDepartment { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();    
    }
}
