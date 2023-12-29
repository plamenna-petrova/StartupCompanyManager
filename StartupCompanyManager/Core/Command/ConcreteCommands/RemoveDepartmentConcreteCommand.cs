using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class RemoveDepartmentConcreteCommand : StartupCompanyManagerCommand
    {
        public override string ArgumentsPattern { get; set; } = "[Name]";

        public override string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments)
        {
            startupCompany.StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
               StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
           );

            string removeDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_DEPARTMENT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                startupCompany.Name
            );

            return removeDepartmentConcreteCommandSuccessMessage;
        }

        public override string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments)
        {
            throw new NotImplementedException();
        }
    }
}
