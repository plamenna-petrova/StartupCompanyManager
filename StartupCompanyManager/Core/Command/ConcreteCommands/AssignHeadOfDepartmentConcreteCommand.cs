using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AssignHeadOfDepartmentConcreteCommand : InfoConcreteCommand
    {
        private const int ASSIGN_HEAD_OF_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 2;

        public AssignHeadOfDepartmentConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.ASSIGN_HEAD_OF_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != ASSIGN_HEAD_OF_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        ASSIGN_HEAD_OF_DEPARTMENT_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
                StartupCompanyManagerCommandAction.AssignSuperior, commandExecutionOperationArguments
            );

            string assignHeadOfDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ASSIGNED_HEAD_OF_DEPARTMENT_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1]
            );

            return assignHeadOfDepartmentConcreteCommandSuccessMessage;
        }
    }
}
