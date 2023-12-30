using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System.Globalization;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class DateTimeIncorrectFormatConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return DateTime.TryParseExact((string) input, (string)validationArguments[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
