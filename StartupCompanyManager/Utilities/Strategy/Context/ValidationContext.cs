using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Strategy.Context
{
    public class ValidationContext
    {
        private IValidationStrategy validationStrategy;    

        public ValidationContext(IValidationStrategy validationStrategy)
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
