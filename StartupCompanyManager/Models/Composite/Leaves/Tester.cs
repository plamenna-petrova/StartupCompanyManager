using StartupCompanyManager.Models.Composite.Leaves.Abstraction;

namespace StartupCompanyManager.Models.Composite.Leaves
{
    public class Tester : BaseEmployeeLeaf
    {
        public Tester(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, position, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }

        public override string Designation { get; set; } = nameof(Tester);
    }
}
