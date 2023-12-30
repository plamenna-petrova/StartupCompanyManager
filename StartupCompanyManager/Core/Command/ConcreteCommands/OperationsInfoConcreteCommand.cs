using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Facade;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public partial class OperationsInfoConcreteCommand : StartupCompanyManagerCommand
    {
        private readonly IServiceProvider _serviceProvider;

        [GeneratedRegex("(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace)]
        private static partial Regex CommandNameGenerationRegex();

        public OperationsInfoConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade, IServiceProvider serviceProvider) 
            : base(startupCompanyManagerFacade)
        {
            _serviceProvider = serviceProvider;    
        }

        public override string Execute(params string[] commandExecutionOperationArguments)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            ICollection<Type> startupCompanyManagerCommandTypes = executingAssembly.GetTypes()
                .Where(t => typeof(StartupCompanyManagerCommand).IsAssignableFrom(t) && !t.IsAbstract && t != GetType())
                .ToList();

            StringBuilder operationsInfoStringBuilder = new();

            foreach (Type startupCompanyManagerCommandType in startupCompanyManagerCommandTypes) 
            {
                var foundCommandTypeConstructor = startupCompanyManagerCommandType.GetConstructors().FirstOrDefault()!;

                var foundCommandTypeConstructorParameterTypes = foundCommandTypeConstructor
                    .GetParameters()
                    .Select(p => p.ParameterType)
                    .ToArray();

                var injectedServices = foundCommandTypeConstructorParameterTypes
                    .Select(cpt => _serviceProvider.GetService(cpt))
                    .ToArray();

                var startupCompanyManagerCommandInstance = Activator.CreateInstance(startupCompanyManagerCommandType, injectedServices)!;

                operationsInfoStringBuilder.AppendLine(
                    $"{string.Concat(Enumerable.Repeat("=> ", 3))} " +
                    $"{GenerateCommandName(startupCompanyManagerCommandType.Name)} " +
                    $"{startupCompanyManagerCommandType.GetProperty("ArgumentsPattern")!.GetValue(startupCompanyManagerCommandInstance, null)}"
                );
            }

            operationsInfoStringBuilder.AppendLine($"{string.Concat(Enumerable.Repeat("=> ", 3))} END");

            return operationsInfoStringBuilder.ToString().Trim();
        }

        private string GenerateCommandName(string commandTypeName)
        {
            Regex commandGenerationPattern = CommandNameGenerationRegex();

            List<string> listOfCommandArguments = commandGenerationPattern.Replace(commandTypeName, " ")
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Take(2)
                .ToList();

            listOfCommandArguments[0] = listOfCommandArguments[0].ToUpper();

            string generatedCommandName = string.Join(" ", listOfCommandArguments);

            return generatedCommandName;
        }
    }
}
