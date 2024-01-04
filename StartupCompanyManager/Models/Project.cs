using Microsoft.VisualBasic;
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

        private string name = null!;

        private DateTime assignmentDate = default;

        private DateTime deadline = default;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

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

        public DateTime AssignmentDate { get => assignmentDate; set => assignmentDate = value;}

        public DateTime Deadline { get => deadline; set => deadline = value; }

        public Team Team { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

        public override string ToString()
        {
            return $"{Name}, Assignment Date: {AssignmentDate.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)}, " +
                $"Deadline: {Deadline.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)}";
        }
    }
}
