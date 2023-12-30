using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class RemoveInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        private const int REMOVE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 1;

        public RemoveInvestorConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.REMOVE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != REMOVE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        REMOVE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
            );

            string removeInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.StartupCompanyInstance.Name
            );

            return removeInvestorConcreteCommandSuccessMessage;
        }
    }
}
