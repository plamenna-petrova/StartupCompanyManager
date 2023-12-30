using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class EarlierDateConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return (DateTime) input < (DateTime) validationArguments[0];
        }
    }
}
