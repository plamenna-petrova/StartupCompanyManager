using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class InfoConcreteCommand : StartupCompanyManagerCommand
    {
        public InfoConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            return StartupCompany.StartupCompanyInstance.ToString()!;
        }
    }
}
