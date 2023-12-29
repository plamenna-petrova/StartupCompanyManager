using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Factory.ConcreteCreators;
using StartupCompanyManager.Utilities.Interpreter.Context;
using StartupCompanyManager.Utilities.Interpreter.Expressions.Abstraction;

namespace StartupCompanyManager.Utilities.Interpreter.Expressions
{
    public class ConsoleInputOperationExpression : StartupCompanyOperationAbstractExpression
    {
        private readonly StartupCompanyManagerCommandConcreteCreator _startupCompanyManagerCommandConcreteCreator;

        public ConsoleInputOperationExpression(StartupCompanyManagerCommandConcreteCreator startupCompanyManagerCommandConcreteCreator)
        {
            _startupCompanyManagerCommandConcreteCreator = startupCompanyManagerCommandConcreteCreator;
        }

        public override void Interpret(StartupCompanyManagerOperationsContext startupCompanyManagerOperationContext)
        {
            string[] consoleInputOperationArguments = startupCompanyManagerOperationContext.Input.Split(' ').ToArray();
            string commandType = string.Join(string.Empty, consoleInputOperationArguments.Take(2));
            StartupCompanyManagerCommand startupCompanyManagerCommand = _startupCompanyManagerCommandConcreteCreator.Create(commandType);
            string[] consoleInputCommandExecutionOperationArguments = consoleInputOperationArguments.Skip(2).ToArray();
            startupCompanyManagerOperationContext.Output = startupCompanyManagerCommand.Execute(consoleInputCommandExecutionOperationArguments);
        }
    }
}
