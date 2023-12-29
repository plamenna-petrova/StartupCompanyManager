using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Factory.Creator;
using System.Reflection;

namespace StartupCompanyManager.Core.Factory.ConcreteCreators
{
    public class StartupCompanyManagerCommandConcreteCreator : StartupCompanyManagerCreator<StartupCompanyManagerCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public StartupCompanyManagerCommandConcreteCreator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override StartupCompanyManagerCommand Create(params string[] entityCreationArguments)
        {
            string commandNameToLower = entityCreationArguments[0].ToLower() + GlobalConstants.CONCRETE_COMMAND_SUFIX.ToLower();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            Type? foundCommandType = executingAssembly.GetTypes()
                .Where(t => typeof(StartupCompanyManagerCommand).IsAssignableFrom(t) && !t.IsAbstract)
                .FirstOrDefault(t => t.Name.ToLower() == commandNameToLower)  
                    ?? throw new ArgumentException(
                          ExceptionMessagesConstants.INVALID_STARTUP_COMPANY_MANAGER_OPERATION_EXCEPTION_MESSAGE
                       );

            ConstructorInfo? foundCommandTypeConstructor = foundCommandType.GetConstructors().FirstOrDefault()!;

            Type[]? foundCommandTypeConstructorParameterTypes = foundCommandTypeConstructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            object?[]? injectedServices = foundCommandTypeConstructorParameterTypes.Select(cpt => _serviceProvider.GetService(cpt)).ToArray();

            StartupCompanyManagerCommand startupCompanyManagerCommand = (StartupCompanyManagerCommand) Activator.CreateInstance(
                foundCommandType, injectedServices
            )!;

            return startupCompanyManagerCommand;
        }
    }
}
