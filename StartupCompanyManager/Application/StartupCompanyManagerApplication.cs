using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Utilities.Interpreter.Context;
using StartupCompanyManager.Utilities.Interpreter.Expressions;
using System.Reflection;

namespace StartupCompanyManager.Application
{
    public class StartupCompanyManagerApplication : IStartupCompanyManagerApplication
    {
        private readonly ConsoleInputOperationExpression _consoleInputOperationExpression;

        public StartupCompanyManagerApplication(ConsoleInputOperationExpression consoleInputOperationExpression)
        { 
            _consoleInputOperationExpression = consoleInputOperationExpression;
        }

        public void Run()
        {
            StartupCompany.CreateInstance(
                "DiligentSys",
                80000.00M,
                2018,
                "cutting_edge_tech_focus@gmail.com",
                "9th Street. 47 W 15th St, New York, NY 10011",
                "+1 (646) 555-3890"
            );

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{GlobalConstants.OPERATIONS_INFO}\n");

            string[] splitOperationsInfoConstant = GlobalConstants.OPERATIONS_INFO.Split(" ").ToArray();

            string[] operationsInfoCommandPrefixTokens = splitOperationsInfoConstant
                .Skip(splitOperationsInfoConstant.Length - 2)
                .Take(2)
                .ToArray();

            StartupCompanyManagerOperationsContext startupCompanyManagerOperationsContext = new(
                string.Join(string.Empty, operationsInfoCommandPrefixTokens)
            );

            Console.ForegroundColor = ConsoleColor.White;   

            _consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);

            Console.WriteLine(startupCompanyManagerOperationsContext.Output + "\r\n");

            string consoleInputCommand = Console.ReadLine()!;

            while (consoleInputCommand != "END")
            {
                try
                {
                    startupCompanyManagerOperationsContext.Input = consoleInputCommand;
                    _consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);

                    if (!string.IsNullOrEmpty(startupCompanyManagerOperationsContext.Output))
                    {
                        if (consoleInputCommand.ToLower() == GlobalConstants.INFO_OPERATION.ToLower())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.WriteLine(startupCompanyManagerOperationsContext.Output);
                    }
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    if (exception is TargetInvocationException)
                    {
                        if (exception.InnerException != null)
                        {
                            Console.WriteLine(exception.InnerException.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                consoleInputCommand = Console.ReadLine()!;
            }
        }
    }
}
