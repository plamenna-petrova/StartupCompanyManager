using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AssignHeadOfDepartmentTeamLeadSubordinateConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ASSIGN_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AssignHeadOfDepartmentTeamLeadSubordinateConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ASSIGN_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ASSIGN_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ASSIGN_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
                StartupCompanyManagerCommandAction.AssignSubordinate, commandExecutionOperationArguments
            );

            string assignHeadOfDepartmentTeamLeadSubordinateConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ASSIGNED_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1]
            );

            return assignHeadOfDepartmentTeamLeadSubordinateConcreteCommandSuccessMessage;
        }
    }
}
