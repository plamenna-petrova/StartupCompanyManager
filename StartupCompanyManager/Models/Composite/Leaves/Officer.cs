using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Leaves
{
    public class Officer : Employee
    {
        public Officer(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, position, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }

        public override void Add(Employee employee)
        {
            throw new InvalidOperationException(
                string.Format(ExceptionMessagesConstants.CANNOT_ADD_ELEMENT_TO_LEAF_EXCEPTION_MESSAGE, GetType().Name)
            );
        }

        public override void Remove(Employee employee)
        {
            throw new InvalidOperationException(
                string.Format(ExceptionMessagesConstants.CANNOT_REMOVE_ELEMENT_FROM_LEAF_EXCEPTION_MESSAGE, GetType().Name)
            );
        }

        public override string GetHierarchicalLevel(int depthIndicator)
        {
            return $"{new string(' ', depthIndicator)}{new string('-', depthIndicator)}+ Officer: {FullName}, " +
                $"Position: [{Position}], Monthly Salary: [${MonthlySalary}] Years of Work Experience: [{YearsOfWorkExperience}], " +
                $"Birth Date: {BirthDate.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)}, Rating: {Rating}\r\n";
        }
    }
}
