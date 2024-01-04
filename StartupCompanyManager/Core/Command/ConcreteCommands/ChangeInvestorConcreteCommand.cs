using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class ChangeInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        private const int CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 3;

        public ChangeInvestorConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.CHANGE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Change, commandExecutionOperationArguments
            );

            return null!;
        }
    }
}
