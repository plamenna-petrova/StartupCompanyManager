using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AssignTeamLeadConcreteCommand : InfoConcreteCommand
    {
        private const int ASSIGN_TEAM_LEAD_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AssignTeamLeadConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ASSIGN_TEAM_LEAD_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ASSIGN_TEAM_LEAD_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ASSIGN_TEAM_LEAD_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteTeamRelatedOperation(
                StartupCompanyManagerCommandAction.AssignSuperior, commandExecutionOperationArguments
            );

            string assignHeadOfDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ASSIGNED_TEAM_LEAD_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1]
            );

            return assignHeadOfDepartmentConcreteCommandSuccessMessage;
        }
    }
}
