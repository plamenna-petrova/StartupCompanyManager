using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddEmployeeConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_EMPLOYEE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 8;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly DateTimeIncorrectFormatConcreteValidationStrategy _dateTimeIncorrectFormatConcreteValidationStrategy = new();

        public AddEmployeeConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_EMPLOYEE_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_EMPLOYEE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ADD_EMPLOYEE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(_dateTimeIncorrectFormatConcreteValidationStrategy);

            if (!_startupCompanyManagerValidationContext.ValidateInput(
                commandExecutionOperationArguments[6], GlobalConstants.DATE_TIME_VALUE_FORMAT
            ))
            {
                throw new ArgumentException(ValidationConstants.EMPLOYEE_BIRTH_DATE_INCORRECT_FORMAT_ERROR_MESSAGE);
            }

            _startupCompanyManagerValidationContext.SetValidationStrategy(null!);

            DateTime exactlyParsedEmployeeBirthDate = ((string)commandExecutionOperationArguments[6]).ParseDateTimeExactly();

            StartupCompanyManagerFacade.ExecuteEmployeeRelatedOperation(
                StartupCompanyManagerCommandAction.Add,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1],
                commandExecutionOperationArguments[2],
                commandExecutionOperationArguments[3],
                commandExecutionOperationArguments[4],
                commandExecutionOperationArguments[5],
                exactlyParsedEmployeeBirthDate,
                commandExecutionOperationArguments[7]
            );

            string addEmployeeConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_EMPLOYEE_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                $"{commandExecutionOperationArguments[1]} {commandExecutionOperationArguments[2]}",
                StartupCompany.StartupCompanyInstance.Name
            );

            return addEmployeeConcreteCommandSuccessMessage;
        }
    }
}
