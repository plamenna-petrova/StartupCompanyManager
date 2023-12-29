using System.Text.RegularExpressions;
using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class RegexPatternConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return Regex.IsMatch((string)input, (string)validationArguments[0]);
        }
    }
}
