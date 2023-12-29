using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;

namespace StartupCompanyManager.Models
{
    public class Department : BaseModel
    {
        public Department(string name, int yearOfEstablishment)
        {
            Name = name;
            YearOfEstablishment = yearOfEstablishment;
        }

        public string Name { get; set; } = null!;

        public int YearOfEstablishment { get; set; }

        public HeadOfDepartment HeadOfDepartment { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();    
    }
}
