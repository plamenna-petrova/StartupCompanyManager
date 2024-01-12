using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Composite.Leaves.Abstraction;

namespace StartupCompanyManager.Models.Composite.Leaves
{
    public class SoftwareDeveloper : BaseEmployeeLeaf
    {
        public SoftwareDeveloper(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating) 
            : base(firstName, lastName, position, monthlySalary, yearsOfWorkExperience, birthDate, rating)
        {

        }
    }
}
