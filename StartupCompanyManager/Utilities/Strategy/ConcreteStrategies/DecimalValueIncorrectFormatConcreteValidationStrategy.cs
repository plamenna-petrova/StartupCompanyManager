using StartupCompanyManager.Utilities.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class DecimalValueIncorrectFormatConcreteValidationStrategy : IValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return decimal.TryParse((string)input, out decimal _);
        }
    }
}
