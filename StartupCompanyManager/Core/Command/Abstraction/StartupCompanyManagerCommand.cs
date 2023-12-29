using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.Abstraction
{
    public abstract class StartupCompanyManagerCommand
    {
        public virtual string ArgumentsPattern { get; set; } = null;

        public abstract string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments);

        public abstract string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments);
    }
}
