using StartupCompanyManager.Core.Adapter.Interfaces;

namespace StartupCompanyManager.Core.Adapter
{
    public class StartupCompanyDataConverterAdapter : IStartupCompanyDataConverterTarget
    {
        private readonly StartupCompanyXMLDataConverterAdaptee startupCompanyXMLDataConverterAdaptee = new();

        public void SaveStartupCompanyDataToXMLFile()
        {
            startupCompanyXMLDataConverterAdaptee.ConvertStartupCompanyDataToXML();
        }
    }
}
