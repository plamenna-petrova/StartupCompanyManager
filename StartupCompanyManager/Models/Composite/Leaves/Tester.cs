using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Leaves
{
    public class Tester : Employee
    {
        public Tester(string firstName, string lastName, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, monthlySalary, yearsOfWorkExperience, birthDate, rating)
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

        public override void GetHierarchicalLevel(int depthIndicator)
        {
            Console.WriteLine($"{new string('-', depthIndicator)} {FullName} [{GetType().Name}] [${MonthlySalary}]");
        }
    }
}
