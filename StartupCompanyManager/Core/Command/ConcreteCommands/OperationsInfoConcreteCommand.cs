using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class OperationsInfoConcreteCommand : StartupCompanyManagerCommand
    {
        public override string Execute(IStartupCompany startupCompany, params string[] commandExecutionOperationArguments)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            ICollection<Type> startupCompanyManagerCommandTypes = executingAssembly.GetTypes()
                .Where(t => typeof(StartupCompanyManagerCommand).IsAssignableFrom(t) && !t.IsAbstract && t != GetType())
                .ToList();

            StringBuilder operationsInfoStringBuilder = new();

            foreach (Type startupCompanyManagerCommandType in startupCompanyManagerCommandTypes) 
            {
                object startupCompanyManagerCommandInstance = Activator.CreateInstance(startupCompanyManagerCommandType);

                operationsInfoStringBuilder.AppendLine(
                    $"{string.Concat(Enumerable.Repeat("=> ", 3))} " +
                    $"{GenerateCommandName(startupCompanyManagerCommandType.Name)} " +
                    $"{startupCompanyManagerCommandType.GetProperty("ArgumentsPattern").GetValue(startupCompanyManagerCommandInstance, null)}"
                );
            }

            operationsInfoStringBuilder.AppendLine($"{string.Concat(Enumerable.Repeat("=> ", 3))} END");

            return operationsInfoStringBuilder.ToString().Trim();
        }

        public override string Undo(IStartupCompany startupCompany, params string[] commandUndoOperationArguments)
        {
            throw new NotImplementedException();
        }

        private string GenerateCommandName(string commandTypeName)
        {
            Regex commandGenerationPattern = new Regex(
                @"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])",
                RegexOptions.IgnorePatternWhitespace
            );

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
