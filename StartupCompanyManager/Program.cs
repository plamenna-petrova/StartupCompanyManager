
using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Utilities.Interpreter.Context;
using StartupCompanyManager.Utilities.Interpreter.Expessions;
using StartupCompanyManager.Utilities.Interpreter.Expessions.Abstraction;

StartupCompany.CreateInstance(
    "CuttingEdgeFocus Tech", 
    80.0000M, 
    "9th Street. 47 W 15th St, New York, NY 10011", 
    "+1 (646) 555-3890", "cutting_edge_tech_focus@gmail.com", 
    "https://cutting-edge-tech.com"
);

Console.WriteLine($"{GlobalConstants.OPERATIONS_INFO} \n");

string[] splittedOperationsInfoConstant = GlobalConstants.OPERATIONS_INFO.Split(" ").ToArray();
string[] operationsInfoCommandPrefixTokens = splittedOperationsInfoConstant.Skip(splittedOperationsInfoConstant.Length - 2).Take(2).ToArray();

StartupCompanyManagerOperationsContext startupCompanyManagerOperationsContext = new StartupCompanyManagerOperationsContext(
    string.Join(string.Empty, operationsInfoCommandPrefixTokens)
);

StartupCompanyOperationAbstractExpression consoleInputOperationExpression = new ConsoleInputOperationExpression(
    StartupCompany.StartupCompanyInstance
);

consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);
Console.WriteLine(startupCompanyManagerOperationsContext.Output);

Console.WriteLine();

string consoleInputCommand = Console.ReadLine();

while (consoleInputCommand != "END")
{
    try
    {
        startupCompanyManagerOperationsContext.Input = consoleInputCommand;
        consoleInputOperationExpression.Interpret(startupCompanyManagerOperationsContext);
        Console.WriteLine(startupCompanyManagerOperationsContext.Output);
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }

    consoleInputCommand = Console.ReadLine();
}