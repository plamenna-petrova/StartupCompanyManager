using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Leafs
{
    public class Officer : Employee
    {
        public Officer(string firstName, string lastName, string position, int yearsOfWorkExperience, decimal salary)
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
