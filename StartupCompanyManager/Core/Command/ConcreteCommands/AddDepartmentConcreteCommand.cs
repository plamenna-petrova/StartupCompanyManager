using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddDepartmentConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AddDepartmentConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ADD_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.StartupCompanyInstance.Name
            );

            return addDepartmentConcreteCommandSuccessMessage;
        }
    }
}
