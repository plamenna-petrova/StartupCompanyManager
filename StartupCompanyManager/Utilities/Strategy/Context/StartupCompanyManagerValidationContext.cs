using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.Context
{
    public class StartupCompanyManagerValidationContext
    {
        private IStartupCompanyManagerValidationStrategy validationStrategy = null!;

        public StartupCompanyManagerValidationContext()
        {
            
        }

        public StartupCompanyManagerValidationContext(IStartupCompanyManagerValidationStrategy validationStrategy) : this()
        {
            this.validationStrategy = validationStrategy;
        }

        public void SetValidationStrategy(IStartupCompanyManagerValidationStrategy validationStrategy)
        {
            this.validationStrategy = validationStrategy;
        }

        public bool ValidateInput(object input, params object[] validationArguments) 
            => validationStrategy.ValidateInput(input, validationArguments);
    }
}
