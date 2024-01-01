using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class TotalDaysDifferenceConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            var dateTimeComparisonResult = DateTime.Compare((DateTime)input, (DateTime)validationArguments[0]);

            if (dateTimeComparisonResult > 0)
            {
                return false;
            }

            return ((DateTime)validationArguments[0] - (DateTime) input).TotalDays >= (int) validationArguments[1];
        }
    }
}
