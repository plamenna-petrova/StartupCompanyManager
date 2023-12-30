using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models
{
    public class Project : BaseModel
    {
        private const int MINIMUM_PROJECT_NAME_LENGTH = 5;

        private const int MAXIMUM_PROJECT_NAME_LENGTH = 32;

        private const int PROJECT_MINIMUM_EXECUTION_DAYS = 30;

        private string name = null!;

        private DateTime assignmentDate = default;

        private DateTime deadline = default;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly DateTimeIncorrectFormatConcreteValidationStrategy _dateTimeIncorrectFormatConcreteValidationStrategy = new();

        private readonly TotalDaysDifferenceConcreteValidationStrategy _totalDaysDifferenceConcreteValidationStrategy = new();

        public Project(string name, DateTime assignmentDate, DateTime deadline)
        {
            Name = name;
            AssignmentDate = assignmentDate;
            Deadline = deadline;
        }

        public string Name
        {
            get => name;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_PROJECT_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_PROJECT_NAME_LENGTH, MAXIMUM_PROJECT_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.PROJECT_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_PROJECT_NAME_LENGTH,
                            MAXIMUM_PROJECT_NAME_LENGTH
                        )
                    );
                }

                name = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public DateTime AssignmentDate
        {
            get => assignmentDate;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, GlobalConstants.DATE_TIME_VALUE_FORMAT))
                {
                    throw new ArgumentException(ValidationConstants.PROJECT_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                assignmentDate = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public DateTime Deadline
        {
            get => deadline;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, GlobalConstants.DATE_TIME_VALUE_FORMAT))
                {
                    throw new ArgumentException(ValidationConstants.PROJECT_DEADLINE_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_totalDaysDifferenceConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value.Date, AssignmentDate.Date, PROJECT_MINIMUM_EXECUTION_DAYS
                ))
                {
                    throw new ArgumentException(
                        string.Format(ValidationConstants.PROJECT_EXECUTION_DAYS_ERROR_MESSAGE, PROJECT_MINIMUM_EXECUTION_DAYS)
                    );
                }

                deadline = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public Team Team { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
