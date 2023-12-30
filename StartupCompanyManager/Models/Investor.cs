using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models
{
    public class Investor : BaseModel
    {
        private const int MINIMUM_INVESTOR_NAME_LENGTH = 4;

        private const int MAXIMUM_INVESTOR_NAME_LENGTH = 35;

        private const decimal MINIMUM_INVESTOR_FUNDS = 5.0000M;

        private string name = null!;

        private decimal funds = default;

        private readonly StartupCompanyManagerValidationContext validationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy nullOrWhiteSpaceStringValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy stringLengthRangeValidationStrategy = new();

        private readonly DecimalValueIncorrectFormatConcreteValidationStrategy decimalValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly MinNumberConcreteValidationStrategy minNumberConcreteValidationStrategy = new();

        public Investor(string name, decimal funds)
        {
            Name = name;
            Funds = funds;
        }

        public string Name
        {
            get => name;
            set
            {
                validationContext.SetValidationStrategy(nullOrWhiteSpaceStringValidationStrategy);

                if (validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_INVESTOR_NAME_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(stringLengthRangeValidationStrategy);

                if (!validationContext.ValidateInput(
                    value, MINIMUM_INVESTOR_NAME_LENGTH, MAXIMUM_INVESTOR_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.INVESTOR_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_INVESTOR_NAME_LENGTH,
                            MAXIMUM_INVESTOR_NAME_LENGTH
                        )
                    );
                }

                name = value;

                validationContext.SetValidationStrategy(null!);
            }
        }

        public decimal Funds
        {
            get => funds;
            set
            {
                validationContext.SetValidationStrategy(decimalValueIncorrectFormatConcreteValidationStrategy);

                if (!validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.INVESTOR_FUNDS_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(minNumberConcreteValidationStrategy);

                if (!validationContext.ValidateInput(value, MINIMUM_INVESTOR_FUNDS))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.INVESTOR_FUNDS_MINIMUM_VALUE_ERROR_MESSAGE, 
                            MINIMUM_INVESTOR_FUNDS
                        )
                    );
                }

                funds = value;

                validationContext.SetValidationStrategy(null!);
            }
        }
    }
}
