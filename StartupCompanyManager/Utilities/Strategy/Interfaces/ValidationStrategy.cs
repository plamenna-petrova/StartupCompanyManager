using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Strategy.Interfaces
{
    public interface IValidationStrategy
    {
        bool ValidateInput(object input, params object[] validationArguments);
    }
}
