using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models
{
    public class Department : BaseModel
    {
        private const int MINIMUM_DEPARTMENT_NAME_LENGTH = 2;

        private const int MAXIMUM_DEPARTMENT_NAME_LENGTH = 25;

        private const int EARLIEST_ALLOWED_DEPARTMENT_YEAR_OF_ESTABLISHMENT = 2012;

        private string name = null!;

        private int yearOfEstablishment = default;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly IntegerValueIncorrectFormatConcreteValidationStrategy _integerValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly IntegersNumberRangeConcreteValidationStrategy _integersRangeConcreteValidationStrategy = new();

        public Department(string name, int yearOfEstablishment)
        {
            Name = name;
            YearOfEstablishment = yearOfEstablishment;
        }

        public string Name 
        {
            get => name;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_DEPARTMENT_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_DEPARTMENT_NAME_LENGTH, MAXIMUM_DEPARTMENT_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.DEPARTMENT_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_DEPARTMENT_NAME_LENGTH,
                            MAXIMUM_DEPARTMENT_NAME_LENGTH
                        )
                    );
                }

                name = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        } 

        public int YearOfEstablishment
        {
            get => yearOfEstablishment;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_integerValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.DEPARTMENT_YEAR_OF_ESTABLISHMENT_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_integersRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, EARLIEST_ALLOWED_DEPARTMENT_YEAR_OF_ESTABLISHMENT, DateTime.Today.Year
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.DEPARTMENT_YEAR_OF_ESTABLISHMENT_NUMBER_RANGE_ERROR_MESSAGE,
                            EARLIEST_ALLOWED_DEPARTMENT_YEAR_OF_ESTABLISHMENT,
                            DateTime.Today.Year
                        )
                    );
                }

                yearOfEstablishment = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public HeadOfDepartment HeadOfDepartment { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();    
    }
}
