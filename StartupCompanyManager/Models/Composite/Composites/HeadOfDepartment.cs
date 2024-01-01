using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Composites
{
    public class HeadOfDepartment : Employee
    {
        public HeadOfDepartment(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, position, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public override void Add(Employee employee)
        {
            if (employee is TeamLead)
            {
                Employees.Add(employee);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessagesConstants.ONLY_TEAM_LEADS_SUBORDINATES_ALLOWED_FOR_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE)
                );
            }
        }

        public override void Remove(Employee employee)
        {
            Employees.Remove(employee);
        }

        public override string GetHierarchicalLevel(int depthIndicator)
        {
            string headOfDepartmentHierarchicalInfo = $"{new string('-', depthIndicator)}+ " +
                $"Head Of Department: {FullName}, Position: {Position}, Monthly Salary: ${MonthlySalary}, " +
                $"Years of Work Experience: {YearsOfWorkExperience}, Birth Date: {BirthDate.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)}, " +
                $"Rating: {Rating}\r\n";

            foreach (var employee in Employees)
            {
                headOfDepartmentHierarchicalInfo += employee.GetHierarchicalLevel(depthIndicator + 2);
            }

            return headOfDepartmentHierarchicalInfo;
        }
    }
}
