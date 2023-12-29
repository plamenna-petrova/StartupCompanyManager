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
        public AddInvestorConcreteCommand(StartupCompany startupCompany, StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompany, startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; set; } = "[Name] [Funds]";

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            decimal oldStartupCompanyCapital = StartupCompany.Capital;

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.Name,
                $"{Math.Round(oldStartupCompanyCapital, 2):F3}",
                $"{Math.Round(StartupCompany.Capital, 2):F3}"
            );

            return addInvestorConcreteCommandSuccessMessage;
        }
    }
}
