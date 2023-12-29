using StartupCompanyManager.Utilities.Interpreter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Interpreter.Expessions.Abstraction
{
    public abstract class StartupCompanyOperationAbstractExpression
    {
        public abstract void Interpret(StartupCompanyManagerOperationsContext operationContext);
    }
}
