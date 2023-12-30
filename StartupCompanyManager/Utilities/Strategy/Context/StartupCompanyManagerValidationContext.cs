using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.Context
{
    public class StartupCompanyManagerValidationContext
    {
        private IStartupCompanyManagerValidationStrategy _startupCompanyManagerValidationStrategy = null!;

        public StartupCompanyManagerValidationContext()
        {
            
        }

        public StartupCompanyManagerValidationContext(IStartupCompanyManagerValidationStrategy validationStrategy) : this()
        {
            _startupCompanyManagerValidationStrategy = validationStrategy;
        }

        public void SetValidationStrategy(IStartupCompanyManagerValidationStrategy validationStrategy)
        {
            _startupCompanyManagerValidationStrategy = validationStrategy;
        }

        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return _startupCompanyManagerValidationStrategy.ValidateInput(input, validationArguments);
        }
    }
}
