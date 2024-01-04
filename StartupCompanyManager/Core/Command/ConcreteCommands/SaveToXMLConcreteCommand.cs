using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Adapter;
using StartupCompanyManager.Core.Adapter.Interfaces;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Core.Facade;

namespace StartupCompanyManager.Core.Command.ConcreteCommands
{
    public class SaveToXMLConcreteCommand : StartupCompanyManagerCommand
    {
        private IStartupCompanyDataConverterTarget startupCompanyDataConverterAdapter = new StartupCompanyDataConverterAdapter();

        public SaveToXMLConcreteCommand(StartupCompanyManagerFacade startupCompanyManagerFacade) 
            : base(startupCompanyManagerFacade)
        {

        }

        public override string Execute(params object[] commandExecutionOperationArguments)
        {
            startupCompanyDataConverterAdapter.SaveStartupCompanyDataToXMLFile();
            return CommandsMessagesConstants.SAVED_STARTUP_COMPANY_DATA_TO_XML_FILE_SUCCESS_MESSAGE;
        }
    }
}
