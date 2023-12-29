using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.Abstraction
{
    public abstract class StartupCompanyManagerCommand
    {
        public StartupCompanyManagerCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
        {
            StartupCompanyManagerFacade = startupCompanyManagerFacade;
        }

        public StartupCompanyManagerFacade StartupCompanyManagerFacade { get; set; }

        public virtual string ArgumentsPattern { get; set; } = null!;

        public abstract string Execute(params string[] commandExecutionOperationArguments);
    }
}
