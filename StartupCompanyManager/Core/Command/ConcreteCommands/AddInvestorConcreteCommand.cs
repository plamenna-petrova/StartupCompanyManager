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
    public class AddInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        public override string ArgumentsPattern { get; set; } = "[Name] [Funds]";

        public override string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments)
        {
            decimal oldStartupCompanyCapital = startupCompany.Capital;

            startupCompany.StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE, 
                commandExecutionOperationArguments[0], 
                startupCompany.Name,
                $"{Math.Round(oldStartupCompanyCapital, 2):F3}",
                $"{Math.Round(startupCompany.Capital, 2):F3}"
            );

            return addInvestorConcreteCommandSuccessMessage;
        }

        public override string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments)
        {
            throw new NotImplementedException();
        }
    }
}
