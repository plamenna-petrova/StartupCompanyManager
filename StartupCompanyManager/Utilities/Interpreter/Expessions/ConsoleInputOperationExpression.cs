using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Factory.ConcreteCreators;
using StartupCompanyManager.Core.Factory.Creator;
using StartupCompanyManager.Models.Interfaces;
using StartupCompanyManager.Utilities.Interpreter.Context;
using StartupCompanyManager.Utilities.Interpreter.Expessions.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Interpreter.Expessions
{
    public class ConsoleInputOperationExpression : StartupCompanyOperationAbstractExpression
    {
        private readonly IStartupCompany startupCompany;

        private readonly StartupCompanyManagerCreator<StartupCompanyManagerCommand> startupCompanyManagerCreator;

        public ConsoleInputOperationExpression(IStartupCompany startupCompany)
        {
            this.startupCompany = startupCompany;
            this.startupCompanyManagerCreator = new StartupCompanyManagerCommandConcreteCreator();
        }

        public override void Interpret(StartupCompanyManagerOperationsContext startupCompanyManagerOperationContext)
        {
            string[] consoleInputOperationArguments = startupCompanyManagerOperationContext.Input.Split(' ').ToArray();
            string commandType = string.Join(string.Empty, consoleInputOperationArguments.Take(2));
            StartupCompanyManagerCommand startupCompanyManagerCommand = startupCompanyManagerCreator.Create(commandType);
            string[] consoleInputCommandExecutionOperationArguments = consoleInputOperationArguments.Skip(2).ToArray();

            startupCompanyManagerOperationContext.Output = startupCompanyManagerCommand.Execute(
                startupCompany, consoleInputCommandExecutionOperationArguments
            );
        }
    }
}
