using StartupCompanyManager.Utilities.Interpreter.Context;

namespace StartupCompanyManager.Utilities.Interpreter.Expressions.Abstraction
{
    public abstract class StartupCompanyOperationAbstractExpression
    {
        public abstract void Interpret(StartupCompanyManagerOperationsContext operationContext);
    }
}
