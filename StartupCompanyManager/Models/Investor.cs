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

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly DecimalValueIncorrectFormatConcreteValidationStrategy _decimalValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly MinNumberConcreteValidationStrategy _minNumberConcreteValidationStrategy = new();

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
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_INVESTOR_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
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

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public decimal Funds
        {
            get => funds;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_decimalValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.INVESTOR_FUNDS_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_minNumberConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, MINIMUM_INVESTOR_FUNDS))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.INVESTOR_FUNDS_MINIMUM_VALUE_ERROR_MESSAGE, 
                            MINIMUM_INVESTOR_FUNDS
                        )
                    );
                }

                funds = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }
    }
}
