using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AssignTeamLeadEmployeeSubordinateConcreteCommand : StartupCompanyManagerCommand
    {
        private const int ASSIGN_TEAM_LEAD_EMPLOYEE_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AssignTeamLeadEmployeeSubordinateConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ASSIGN_TEAM_LEAD_EMPLOYEE_SUBORDINATE_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ASSIGN_TEAM_LEAD_EMPLOYEE_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ASSIGN_TEAM_LEAD_EMPLOYEE_SUBORDINATE_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteTeamRelatedOperation(
                StartupCompanyManagerCommandAction.AssignSubordinate, commandExecutionOperationArguments
            );

            string assignTeamLeadEmployeeSubordinateConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ASSIGNED_TEAM_LEAD_EMPLOYEE_SUBORDINATE_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1]
            );

            return assignTeamLeadEmployeeSubordinateConcreteCommandSuccessMessage;
        }
    }
}
