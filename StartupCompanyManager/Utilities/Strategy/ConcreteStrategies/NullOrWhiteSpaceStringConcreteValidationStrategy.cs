using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class NullOrWhiteSpaceStringConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return string.IsNullOrWhiteSpace((string)input);
        }
    }
}
