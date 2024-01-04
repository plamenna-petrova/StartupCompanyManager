using System.Xml.Linq;

namespace StartupCompanyManager.Core.Adapter.Interfaces
{
    public interface IStartupCompanyDataConverterTarget
    {
        void SaveStartupCompanyDataToXMLFile();
    }
}
