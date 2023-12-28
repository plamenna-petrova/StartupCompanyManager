using StartupCompanyManager.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Website { get; set; } = null!;

        public string Activity { get; set; } = null!;   

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
