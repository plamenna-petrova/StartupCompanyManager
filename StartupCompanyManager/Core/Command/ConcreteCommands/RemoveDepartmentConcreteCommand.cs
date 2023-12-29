using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Interfaces;
using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class RemoveDepartmentConcreteCommand : StartupCompanyManagerCommand
    {
        public RemoveDepartmentConcreteCommand(StartupCompany startupCompany, StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompany, startupCompanyManagerFacade) 
        {
            
        }

        public override string ArgumentsPattern { get; set; } = "[Name]";

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
               StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
            );

            string removeDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_DEPARTMENT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                null
            );

            return removeDepartmentConcreteCommandSuccessMessage;
        }
    }
}
