using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Models.Interfaces;
using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.Abstraction
{
    public abstract class StartupCompanyManagerCommand
    {
        public StartupCompanyManagerCommand(StartupCompany startupCompany, StartupCompanyManagerFacade startupCompanyManagerFacade)
        {
            StartupCompany = startupCompany;
            StartupCompanyManagerFacade = startupCompanyManagerFacade;
        }

        public StartupCompany StartupCompany { get; set; }

        public StartupCompanyManagerFacade StartupCompanyManagerFacade { get; set; }

        public virtual string ArgumentsPattern { get; set; } = null!;

        public abstract string Execute(params string[] commandExecutionOperationArguments);
    }
}
