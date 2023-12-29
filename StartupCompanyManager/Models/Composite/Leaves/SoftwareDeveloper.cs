using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Leaves
{
    public class SoftwareDeveloper : Employee
    {
        public SoftwareDeveloper(string firstName, string lastName, string position, int yearsOfWorkExperience, decimal salary)
            : base(firstName, lastName, position, yearsOfWorkExperience, salary)
        {

        }

        public override void Add(Employee employee)
        {
            Console.WriteLine($"Cannot add to a {GetType().Name}");
        }

        public override void Remove(Employee employee)
        {
            Console.WriteLine($"Cannot remove from a {GetType().Name}");
        }

        public override void GetHierarchicalLevel(int depthIndicator)
        {
            Console.WriteLine($"{new string('-', depthIndicator)} {FullName} [{Position}] [${Salary}]");
        }
    }
}
