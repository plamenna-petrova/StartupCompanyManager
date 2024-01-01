using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System.Reflection;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class ExistingEnumNameConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyEnumTypes = executingAssembly.GetTypes().Where(t => t.IsEnum);
            var targetEnumType = assemblyEnumTypes.FirstOrDefault(et => et.Name == (string)validationArguments[0]);
            return targetEnumType != null && Enum.GetNames(targetEnumType).Contains(input);
        }
    }
}
