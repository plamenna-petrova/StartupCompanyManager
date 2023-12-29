using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Factory.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Factory.ConcreteCreators
{
    public class StartupCompanyManagerCommandConcreteCreator : StartupCompanyManagerCreator<StartupCompanyManagerCommand>
    {
        public override StartupCompanyManagerCommand Create(params string[] entityCreationArguments)
        {
            string loweredCommandName = entityCreationArguments[0].ToLower() + GlobalConstants.CONCRETE_COMMAND_SUFIX.ToLower();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            Type foundCommandType = executingAssembly.GetTypes()
                .Where(t => typeof(StartupCompanyManagerCommand).IsAssignableFrom(t) && !t.IsAbstract)
                .FirstOrDefault(t => t.Name.ToLower() == loweredCommandName);

            if (foundCommandType == null)
            {
                throw new ArgumentException(
                    ExceptionMessagesConstants.INVALID_STARTUP_COMPANY_MANAGER_OPERATION_EXCEPTION_MESSAGE
                );
            }

            StartupCompanyManagerCommand startupCompanyManagerCommand = (StartupCompanyManagerCommand)Activator.CreateInstance(foundCommandType);

            return startupCompanyManagerCommand;
        }
    }
}
