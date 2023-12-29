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
        public StartupCompanyManagerCommand(StartupCompanyManagerFacade startupCompanyManagerFacade)
        {
            StartupCompanyManagerFacade = startupCompanyManagerFacade;
        }

        public StartupCompanyManagerFacade StartupCompanyManagerFacade { get; set; }

        public virtual string ArgumentsPattern { get; set; } = null!;

        public abstract string Execute(params string[] commandExecutionOperationArguments);
    }
}
