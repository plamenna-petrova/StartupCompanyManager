using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddTeamConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ADD_TEAM_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AddTeamConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ADD_TEAM_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ADD_TEAM_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ADD_TEAM_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteTeamRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addTeamToDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_TEAM_TO_DEPARTMENT_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1]
            );

            return addTeamToDepartmentConcreteCommandSuccessMessage;
        }
    }
}
