using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartupCompanyManager.Models.Abstraction;

namespace StartupCompanyManager.Models.Composite.Component
{
    public abstract class Employee : BaseModel
    {
        public Employee(string firstName, string lastName, string position, int yearsOfWorkExperience, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            YearsOfWorkExperience = yearsOfWorkExperience;
            Salary = salary;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public int YearsOfWorkExperience { get; set; }

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public int Rating { get; set; }

        public Team Team { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

        public abstract void Add(Employee employee);

        public abstract void Remove(Employee employee);

        public abstract void GetHierarchicalLevel(int depthIndicator);
    }
}
