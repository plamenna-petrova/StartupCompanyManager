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
    public class AddInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        public AddInvestorConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; set; } = "[Name] [Funds]";

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            decimal oldStartupCompanyCapital = StartupCompany.StartupCompanyInstance.Capital;

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.StartupCompanyInstance.Name,
                $"{Math.Round(oldStartupCompanyCapital, 2):F3}",
                $"{Math.Round(StartupCompany.StartupCompanyInstance.Capital, 2):F3}"
            );

            return addInvestorConcreteCommandSuccessMessage;
        }
    }
}
