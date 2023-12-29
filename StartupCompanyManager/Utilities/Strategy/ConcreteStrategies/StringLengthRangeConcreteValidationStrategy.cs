using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class StringLengthRangeConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((string)input).Length >= (int)validationArguments[0] && ((string)input).Length <= (int)validationArguments[1];
        }
    }
}
