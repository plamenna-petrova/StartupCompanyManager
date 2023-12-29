using StartupCompanyManager.Models.Abstraction;

namespace StartupCompanyManager.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; } = null!;

        public DateTime AssignmentDate { get; set; }

        public DateTime Deadline { get; set; }

        public Team Team { get; set; } = null!;
    }
}
