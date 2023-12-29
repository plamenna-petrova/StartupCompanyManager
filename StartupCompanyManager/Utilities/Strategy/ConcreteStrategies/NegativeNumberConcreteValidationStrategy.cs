using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class NegativeNumberConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return (decimal)input < 0;
        }
    }
}
