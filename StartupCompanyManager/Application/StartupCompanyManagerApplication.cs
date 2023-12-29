using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Utilities.Interpreter.Context;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Utilities.Interpreter.Expessions;

namespace StartupCompanyManager.Application
{
    public class StartupCompanyManagerApplication : IStartupCompanyManagerApplication
    {
        private readonly StartupCompany _startupCompany;

        private readonly ConsoleInputOperationExpression _consoleInputOperationExpression;

        public StartupCompanyManagerApplication(
            StartupCompany startupCompany, 
            ConsoleInputOperationExpression consoleInputOperationExpression
        )
        {
            _startupCompany = startupCompany;
            _consoleInputOperationExpression = consoleInputOperationExpression;
        }

        public void Run()
        {
            _startupCompany.SetCompanyDetails(
                "CuttingEdgeFocus Tech",
                80.0000M,
                "cutting_edge_tech_focus@gmail.com",
                "9th Street. 47 W 15th St, New York, NY 10011",
                "+1 (646) 555-3890"
            );

            Console.WriteLine($"{GlobalConstants.OPERATIONS_INFO} \n");

            string[] splitOperationsInfoConstant = GlobalConstants.OPERATIONS_INFO.Split(" ").ToArray();

            string[] operationsInfoCommandPrefixTokens = splitOperationsInfoConstant
                .Skip(splitOperationsInfoConstant.Length - 2)
                .Take(2)
                .ToArray();

            StartupCompanyManagerOperationsContext startupCompanyManagerOperationsContext = new(
                string.Join(string.Empty, operationsInfoCommandPrefixTokens)
            );

            _consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);

            Console.WriteLine(startupCompanyManagerOperationsContext.Output);
            Console.WriteLine();

            string consoleInputCommand = Console.ReadLine()!;

            while (consoleInputCommand != "END")
            {
                try
                {
                    startupCompanyManagerOperationsContext.Input = consoleInputCommand;
                    _consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);
                    Console.WriteLine(startupCompanyManagerOperationsContext.Output);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                consoleInputCommand = Console.ReadLine()!;
            }
        }
    }
}
