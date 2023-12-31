﻿using StartupCompanyManager.Utilities.Strategy.Interfaces;

namespace StartupCompanyManager.Utilities.Strategy.ConcreteStrategies
{
    public class TotalDaysDifferenceConcreteValidationStrategy : IStartupCompanyManagerValidationStrategy
    {
        public bool ValidateInput(object input, params object[] validationArguments)
        {
            return ((DateTime)validationArguments[0] - (DateTime) input).TotalDays >= (int) validationArguments[1];
        }
    }
}
