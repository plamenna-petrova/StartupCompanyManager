using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Enums;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

namespace StartupCompanyManager.Models
{
    public class Task : BaseModel
    {
        private const int MINIMUM_TASK_NAME_LENGTH = 8;

        private const int MAXIMUM_TASK_NAME_LENGTH = 50;

        private const int TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS = 1;

        private string name = null!;

        private TaskPriority priority = default;

        private TaskStatus status = default;

        private DateTime assignmentDate = default;

        private DateTime dueDate = default;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly DateTimeIncorrectFormatConcreteValidationStrategy _dateTimeIncorrectFormatConcreteValidationStrategy = new();

        private readonly TotalDaysDifferenceConcreteValidationStrategy _totalDaysDifferenceConcreteValidationStrategy = new();

        private readonly ExistingEnumNameConcreteValidationStrategy _existingEnumNameConcreteValidationStrategy = new();

        private readonly EarlierDateConcreteValidationStrategy _earlierDateConcreteValidationStrategy = new();

        public string Name
        {
            get => name;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_TASK_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_TASK_NAME_LENGTH, MAXIMUM_TASK_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.TASK_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_TASK_NAME_LENGTH,
                            MAXIMUM_TASK_NAME_LENGTH
                        )
                    );
                }

                name = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public TaskPriority Priority
        {
            get => priority;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_existingEnumNameConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value, nameof(TaskPriority)))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.TASK_PRIORITY_INCORRECT_OPTION_ERROR_MESAGE, 
                            string.Join(" | ", Enum.GetNames(typeof(TaskPriority))))
                        );
                }

                priority = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public TaskStatus Status
        {
            get => status;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_existingEnumNameConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value, nameof(TaskStatus)))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.TASK_STATUS_INCORRECT_OPTION_ERROR_MESSAGE),
                            string.Join(" | ", Enum.GetNames(typeof(TaskStatus)))
                        );
                }

                status = value;
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
                    throw new ArgumentException(ValidationConstants.TASK_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                if (Project is not null && Project.AssignmentDate != default)
                {
                    _startupCompanyManagerValidationContext.SetValidationStrategy(_earlierDateConcreteValidationStrategy);

                    if (_startupCompanyManagerValidationContext.ValidateInput(value, Project.AssignmentDate))
                    {
                        throw new ArgumentException(
                            string.Format(
                                ValidationConstants.TASK_ASSIGNMENT_DATE_EARLIER_THAN_PROJECT_START_ERROR_MESSAGE,
                                Project.AssignmentDate.ToString()
                            )
                        );
                    }
                }

                assignmentDate = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, GlobalConstants.DATE_TIME_VALUE_FORMAT))
                {
                    throw new ArgumentException(ValidationConstants.TASK_DUE_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_totalDaysDifferenceConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value.Date, AssignmentDate.Date, TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS
                ))
                {
                    throw new ArgumentException(
                        string.Format(ValidationConstants.TASK_EXECUTION_DAYS_ERROR_MESSAGE, TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS)
                    );
                }

                if (Project is not null && Project.Deadline != default)
                {
                    _startupCompanyManagerValidationContext.SetValidationStrategy(_earlierDateConcreteValidationStrategy);

                    if (!_startupCompanyManagerValidationContext.ValidateInput(value, Project.Deadline))
                    {
                        throw new ArgumentException(
                            string.Format(
                                ValidationConstants.TASK_DUE_DATE_AFTER_PROJECT_END_ERROR_MESSAGE,
                                Project.Deadline.ToString()
                            )
                        );
                    }
                }

                dueDate = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public Project Project { get; set; } = null!;

        public Employee Assignee { get; set; } = null!;
    }
}
