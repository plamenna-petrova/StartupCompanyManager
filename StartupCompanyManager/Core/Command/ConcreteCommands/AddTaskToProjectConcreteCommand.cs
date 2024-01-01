using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Models.Enums;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddTaskToProjectConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_TASK_TO_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 7;

        private const int TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS = 1;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly ExistingEnumNameConcreteValidationStrategy _existingEnumNameConcreteValidationStrategy = new();

        private readonly DateTimeIncorrectFormatConcreteValidationStrategy _dateTimeIncorrectFormatConcreteValidationStrategy = new();

        private readonly TotalDaysDifferenceConcreteValidationStrategy _totalDaysDifferenceConcreteValidationStrategy = new();

        public AddTaskToProjectConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_TASK_TO_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_TASK_TO_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ADD_TASK_TO_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            TaskPriority taskPriority;

            _startupCompanyManagerValidationContext.SetValidationStrategy(_existingEnumNameConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(commandExecutionOperationArguments[1], nameof(TaskPriority)))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationConstants.TASK_PRIORITY_INCORRECT_OPTION_ERROR_MESAGE,
                        string.Join(" | ", Enum.GetNames(typeof(TaskPriority))))
                    );
            }
            else
            {
                taskPriority = (TaskPriority)Enum.Parse(typeof(TaskPriority), (string)commandExecutionOperationArguments[1]);
            }

            TaskStatus taskStatus;

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                string.Join(string.Empty, ((string)commandExecutionOperationArguments[2]).Split(" ")), nameof(TaskStatus))
            )
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationConstants.TASK_STATUS_INCORRECT_OPTION_ERROR_MESSAGE),
                        string.Join(" | ", Enum.GetNames(typeof(TaskStatus)))
                    );
            }
            else
            {
                taskStatus = (TaskStatus) Enum.Parse(typeof(TaskStatus), string.Join(string.Empty, ((string)commandExecutionOperationArguments[2]).Split(" ")));
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                commandExecutionOperationArguments[3], GlobalConstants.DATE_TIME_VALUE_FORMAT
            ))
            {
                throw new ArgumentException(ValidationConstants.TASK_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                commandExecutionOperationArguments[4], GlobalConstants.DATE_TIME_VALUE_FORMAT
            ))
            {
                throw new ArgumentException(ValidationConstants.TASK_DUE_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
            }

            DateTime exactlyParsedTaskAssignmentDate = ((string)commandExecutionOperationArguments[3]).ParseDateTimeExactly();
            DateTime exactlyParsedTaskDueDate = ((string)commandExecutionOperationArguments[4]).ParseDateTimeExactly();

            _startupCompanyManagerValidationContext.SetValidationStrategy(_totalDaysDifferenceConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                exactlyParsedTaskAssignmentDate, exactlyParsedTaskDueDate, TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS
            ))
            {
                throw new ArgumentException(
                    string.Format(ValidationConstants.TASK_EXECUTION_DAYS_ERROR_MESSAGE, TASK_DUE_DATE_MINIMUM_EXECUTION_DAYS)
                );
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(null!);

            StartupCompanyManagerFacade.ExecuteTaskRelatedOperation(
                StartupCompanyManagerCommandAction.Add,
                commandExecutionOperationArguments[0],
                taskPriority,
                taskStatus,
                exactlyParsedTaskAssignmentDate,
                exactlyParsedTaskDueDate,
                commandExecutionOperationArguments[5],
                commandExecutionOperationArguments[6]
            );

            string addProjectToTeamConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_TASK_TO_PROJECT_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[6]
            );

            return addProjectToTeamConcreteCommandSuccessMessage;
        }
    }
}
