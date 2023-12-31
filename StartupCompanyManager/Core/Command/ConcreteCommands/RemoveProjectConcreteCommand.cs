using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class RemoveProjectConcreteCommand : StartupCompanyManagerCommand
    {
        private const int REMOVE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 1;

        public RemoveProjectConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.REMOVE_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != REMOVE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        REMOVE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteProjectRelatedOperation(
               StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
            );

            string removeProjectConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_PROJECT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.StartupCompanyInstance.Name
            );

            return removeProjectConcreteCommandSuccessMessage;
        }
    }
}
