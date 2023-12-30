using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Composites
{
    public class TeamLead : Employee
    {
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public override void Add(Employee employee)
        {
            Employees.Add(employee);
        }

        public override void Remove(Employee employee)
        {
            Employees.Remove(employee);
        }

        public override void GetHierarchicalLevel(int depthIndicator)
        {
            Console.WriteLine($"{new string('-', depthIndicator)}+ {FullName} [{Position}] [${MonthlySalary}]");

            foreach (var employee in Employees)
            {
                employee.GetHierarchicalLevel(depthIndicator + 2);
            }
        }
    }
}
