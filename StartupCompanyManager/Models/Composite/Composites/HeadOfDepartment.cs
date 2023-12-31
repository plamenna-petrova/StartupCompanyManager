﻿using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Composites
{
    public class HeadOfDepartment : Employee
    {
        public HeadOfDepartment(string firstName, string lastName, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }

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
            Console.WriteLine($"{new string('-', depthIndicator)}+ {FullName} [{GetType().Name}] [${MonthlySalary}]");

            foreach (var employee in Employees)
            {
                employee.GetHierarchicalLevel(depthIndicator + 2);
            }
        }
    }
}
