using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class TotalDaysDifferenceConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((DateTime)input - (DateTime)validationArguments[0]).TotalDays >= (int) validationArguments[0];
        }
    }
}
