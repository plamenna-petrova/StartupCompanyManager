using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class ChangeInvestorConcreteCommand : StartupCompanyManagerCommand
    {
        private const int CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT = 3;

        public ChangeInvestorConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string ArgumentsPattern { get; protected set; } = CommandsMessagesConstants.CHANGE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN;

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            if (commandExecutionOperationArguments.Length != CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        ExceptionMessagesConstants.INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE,
                        CHANGE_INVESTOR_CONCRETE_COMMAND_EXPECTED_ARGUMENTS_COUNT,
                        commandExecutionOperationArguments.Length
                    )
                );
            }

            decimal oldStartupCompanyCapital = StartupCompany.StartupCompanyInstance.Capital;

            StartupCompanyManagerFacade.ExecuteInvestorRelatedOperation(
                StartupCompanyManagerCommandAction.Change, commandExecutionOperationArguments
            );

            string changeInvestorConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.CHANGED_INVESTOR_OF_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                commandExecutionOperationArguments[1],
                commandExecutionOperationArguments[2]
            );

            if (((string)commandExecutionOperationArguments[1]) == nameof(Investor.Funds))
            {
                string companyCapitalIncreaseAfterInvestorFundsChangeMessage = string.Format(
                    CommandsMessagesConstants.INCREASED_STARTUP_COMPANY_CAPITAL_AFTER_INVESTOR_FUNDS_CHANGE,
                    StartupCompany.StartupCompanyInstance.Name,
                    oldStartupCompanyCapital,
                    StartupCompany.StartupCompanyInstance.Capital
                );

                changeInvestorConcreteCommandSuccessMessage += $"\n{companyCapitalIncreaseAfterInvestorFundsChangeMessage}";
            }

            return changeInvestorConcreteCommandSuccessMessage;
        }
    }
}
