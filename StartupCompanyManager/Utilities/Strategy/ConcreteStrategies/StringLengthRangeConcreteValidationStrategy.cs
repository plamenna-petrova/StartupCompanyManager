using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class StringLengthRangeConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((string)input).Length >= (int)validationArguments[0] && ((string)input).Length <= (int)validationArguments[1];
        }
    }
}
