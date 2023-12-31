using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddProjectConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 4;

        private const int PROJECT_MINIMUM_EXECUTION_DAYS = 30;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly DateTimeIncorrectFormatConcreteValidationStrategy _dateTimeIncorrectFormatConcreteValidationStrategy = new();

        private readonly TotalDaysDifferenceConcreteValidationStrategy _totalDaysDifferenceConcreteValidationStrategy = new();

        public AddProjectConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ADD_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                commandExecutionOperationArguments[1], GlobalConstants.DATE_TIME_VALUE_FORMAT
            ))
            {
                throw new ArgumentException(ValidationConstants.PROJECT_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
            }

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                commandExecutionOperationArguments[2], GlobalConstants.DATE_TIME_VALUE_FORMAT
            ))
            {
                throw new ArgumentException(ValidationConstants.PROJECT_DEADLINE_INCORRECT_FORMAT_ERROR_MESSAGE);
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(_totalDaysDifferenceConcreteValidationStrategy);

            commandExecutionOperationArguments[1].ParseDateTimeExactly(out DateTime exactlyParsedProjectAssignmentDate);
            commandExecutionOperationArguments[2].ParseDateTimeExactly(out DateTime exactlyParsedProjectDeadline);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                exactlyParsedProjectAssignmentDate, exactlyParsedProjectDeadline, PROJECT_MINIMUM_EXECUTION_DAYS
            ))
            {
                throw new ArgumentException(
                    string.Format(ValidationConstants.PROJECT_EXECUTION_DAYS_ERROR_MESSAGE, PROJECT_MINIMUM_EXECUTION_DAYS)
                );
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(null!);

            StartupCompanyManagerFacade.ExecuteProjectRelatedOperation(
                StartupCompanyManagerCommandAction.Add, 
                commandExecutionOperationArguments[0], 
                exactlyParsedProjectAssignmentDate, 
                exactlyParsedProjectDeadline,
                commandExecutionOperationArguments[3]
            );

            string addProjectToTeamConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_PROJECT_TO_TEAM_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[3]
            );

            return addProjectToTeamConcreteCommandSuccessMessage;
        }
    }
}
