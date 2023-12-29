using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Enums;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

namespace StartupCompanyManager.Models
{
    public class Task : BaseModel
    {
        public string Name { get; set; } = null!;

        public TaskPriority Priority { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public Employee Assignee { get; set; } = null!;
    }
}
