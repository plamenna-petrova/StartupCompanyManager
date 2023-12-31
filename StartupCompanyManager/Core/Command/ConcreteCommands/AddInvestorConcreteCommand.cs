using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AddInvestorConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE, 
                        ADD_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            decimal oldStartupCompanyCapital = StartupCompany.StartupCompanyInstance.Capital;

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.StartupCompanyInstance.Name,
                $"{Math.Round(oldStartupCompanyCapital, 2):F3}",
                $"{Math.Round(StartupCompany.StartupCompanyInstance.Capital, 2):F3}"
            );

            return addInvestorConcreteCommandSuccessMessage;
        }
    }
}
