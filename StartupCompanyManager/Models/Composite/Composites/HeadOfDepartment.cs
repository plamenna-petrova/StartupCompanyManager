using StartupCompanyManager.Models.Composite.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models.Composite.Composites
{
    public class HeadOfDepartment : Employee
    {
        public HeadOfDepartment(string firstName, string lastName, string position, int yearsOfWorkExperience, decimal salary) 
            : base(firstName, lastName, position, yearsOfWorkExperience, salary)
        {
        }

        public ICollection<Employee> Employees = new HashSet<Employee>();

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
            Console.WriteLine($"{new string('-', depthIndicator)}+ {FullName} [{Position}] [${Salary}]");

            foreach (var employee in Employees)
            {
                employee.GetHierarchicalLevel(depthIndicator + 2);
            }
        }
    }
}
