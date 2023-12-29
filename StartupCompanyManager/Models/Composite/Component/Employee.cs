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

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string Position { get; set; } = null!;

        public decimal Salary { get; set; } = default;

        public int YearsOfWorkExperience { get; set; } = default;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime BirthDate { get; set; } = default;

        public int Rating { get; set; } = default;

        public Team Team { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

        public abstract void Add(Employee employee);

        public abstract void Remove(Employee employee);

        public abstract void GetHierarchicalLevel(int depthIndicator);
    }
}
