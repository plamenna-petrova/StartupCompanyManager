using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System.Globalization;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class DateTimeIncorrectFormatConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((string)input).ParseDateTimeExactly(out _);
        }
    }
}
