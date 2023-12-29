using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class MaximumStringLengthConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((string)input).Length >= (int)validationArguments[1];
        }
    }
}
