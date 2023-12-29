using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;

namespace StartupCompanyManager.Models
{
    public class Team : BaseModel
    {
        public string Name { get; set; } = null!;

        public Project Project { get; set; } = null!;

        public Department Department { get; set; } = null!;

        public TeamLead TeamLead { get; set; } = null!;
    }
}
