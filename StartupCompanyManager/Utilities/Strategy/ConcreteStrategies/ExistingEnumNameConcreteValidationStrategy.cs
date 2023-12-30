using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System.Reflection;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class ExistingEnumNameConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return Enum.GetNames(Assembly.GetExecutingAssembly().GetType((string)validationArguments[0])!).Contains(input);
        }
    }
}
