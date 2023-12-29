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
    public class RemoveInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        public RemoveInvestorConcreteCommand(StartupCompany startupCompany, StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompany, startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; set; } = "[Name]";

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Remove, commandExecutionOperationArguments
            );

            string removeInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.Name
            );

            return removeInvestorConcreteCommandSuccessMessage;
        }
    }
}
