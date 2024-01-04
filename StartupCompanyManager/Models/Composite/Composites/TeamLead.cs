using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Composites
{
    public class TeamLead : Employee
    {
        public TeamLead(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, position, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public override void Add(Employee employee)
        {
            if (employee is not HeadOfDepartment && employee.GetType() != GetType())
            {
                Employees.Add(employee);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessagesConstants.HEAD_OF_DEPARTMENT_OR_TEAM_LEADS_NOT_ALOWED_FOR_TEAM_LEAD_SUBORDINATES_EXCEPTION_MESSAGE)
                );
            }
        }

        public override void Remove(Employee employee)
        {
            Employees.Remove(employee);
        }

        public override string GetHierarchicalLevel(int depthIndicator)
        {
            string teamLeadHierarchicalLevelInfo = $"{new string('-', depthIndicator)}+ Team Lead: {FullName}, " +
                $"Position: {Position}, Monthly Salary: ${MonthlySalary}, Years of Work Experience: {YearsOfWorkExperience}, " +
                $"Birth Date: {BirthDate.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)}, Rating: {Rating} " +
                $"Team: {(Team != null ? $"{Team.Name}, {(Team.Project != null ? $"Project: {Team.Project.Name},\r\nTasks: {(Team.Project.Tasks.Any() ? $"{string.Join("\r\n", Team.Project.Tasks.Select(t => t.ToString()))}" : "No assigned tasks for project")}" : "No project")}" : "No team")} \r\n";

            foreach (var employee in Employees)
            {
                teamLeadHierarchicalLevelInfo += employee.GetHierarchicalLevel(depthIndicator + 2);
            }

            return teamLeadHierarchicalLevelInfo;
        }
    }
}
