using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class AddDepartmentConcreteCommand : StartupCompanyManagerCommand
    {
        public AddDepartmentConcreteCommand(StartupCompany startupCompany, StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompany, startupCompanyManagerFacade)
        {
            
        }

        public override string ArgumentsPattern { get; set; } = "[Name] [YearOfEstablishment]";

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            StartupCompanyManagerFacade.ExecuteDepartmentRelatedOperation(
                StartupCompanyManagerCommandAction.Add, commandExecutionOperationArguments
            );

            string addDepartmentConcreteCommandSuccessMessage = string.Format(
                CommandsMessagesConstants.ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE,
                commandExecutionOperationArguments[0],
                StartupCompany.Name
            );

            return addDepartmentConcreteCommandSuccessMessage;
        }
    }
}
