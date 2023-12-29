using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.Context
{
    public class ValidationContext
    {
        private IValidationStrategy validationStrategy = null!;

        public ValidationContext()
        {
            
        }

        public ValidationContext(IValidationStrategy validationStrategy) : this()
        {
            this.validationStrategy = validationStrategy;
        }

        public void SetValidationStrategy(IValidationStrategy validationStrategy)
        {
            this.validationStrategy = validationStrategy;
        }

        public bool ValidateInput(object input, params object[] validationArguments) 
            => validationStrategy.ValidateInput(input, validationArguments);
    }
}
