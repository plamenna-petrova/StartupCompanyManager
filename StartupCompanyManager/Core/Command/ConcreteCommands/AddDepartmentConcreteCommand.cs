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
    public class AddDepartmentConcreteCommand : StartupCompanyManagerCommand
    {
        public override string ArgumentsPattern { get; set; } = "[Name] [YearOfEstablishment]";

        public override string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments)
        {
            startupCompany.StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0], 
                startupCompany.Name
            );

            return addDepartmentConcreteCommandSuccessMessage;
        }

        public override string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments)
        {
            throw new NotImplementedException();
        }
    }
}
