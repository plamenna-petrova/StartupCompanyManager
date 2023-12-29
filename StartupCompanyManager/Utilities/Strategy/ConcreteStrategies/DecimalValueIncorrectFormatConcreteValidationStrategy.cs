using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class DecimalValueIncorrectFormatConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return decimal.TryParse((string)input, out decimal _);
        }
    }
}
