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
    public class RemoveInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        public override string ArgumentsPattern { get; set; } = "[Name]";

        public override string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments)
        {
            startupCompany.StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
            );

            string removeInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                startupCompany.Name
            );

            return removeInvestorConcreteCommandSuccessMessage;
        }

        public override string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments)
        {
            throw new NotImplementedException();
        }
    }
}
