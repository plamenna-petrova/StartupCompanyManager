using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class ChangeProjectConcreteCommand : StartupCompanyManagerCommand
    {
        private const int CHANGE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 3;

        public ChangeProjectConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.CHANGE_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != CHANGE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        CHANGE_PROJECT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteProjectRelatedOperation(
                StartupCompanyManagerCommandAction.Change, commandExecutionOperationArguments
            );

            return null!;
        }
    }
}
