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

        private const decimal EARLIEST_ALLOWED_DEPARTMENT_YEAR_OF_ESTABLISHMENT = 2012;

        private string name = null!;

        private int yearOfEstablishment = default;

        private readonly StartupCompanyManagerValidationContext validationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy nullOrWhiteSpaceStringValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy stringLengthRangeValidationStrategy = new();

        private readonly IntegerValueIncorrectFormatConcreteValidationStrategy integerValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly NumberRangeConcreteValidationStrategy numberRangeConcreteValidationStrategy = new();

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
                validationContext.SetValidationStrategy(nullOrWhiteSpaceStringValidationStrategy);

                if (validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_DEPARTMENT_NAME_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(stringLengthRangeValidationStrategy);

                if (!validationContext.ValidateInput(
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

                validationContext.SetValidationStrategy(null!);
            }
        } 

        public int YearOfEstablishment
        {
            get => yearOfEstablishment;
            set
            {
                validationContext.SetValidationStrategy(integerValueIncorrectFormatConcreteValidationStrategy);

                if (!validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.DEPARTMENT_YEAR_OF_ESTABLISHMENT_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(numberRangeConcreteValidationStrategy);

                if (!validationContext.ValidateInput(
                    Convert.ToDecimal(value), EARLIEST_ALLOWED_DEPARTMENT_YEAR_OF_ESTABLISHMENT, DateTime.Today.Year
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

                validationContext.SetValidationStrategy(null!);
            }
        }

        public HeadOfDepartment HeadOfDepartment { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();    
    }
}
