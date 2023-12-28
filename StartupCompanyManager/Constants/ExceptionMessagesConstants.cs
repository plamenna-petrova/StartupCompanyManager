using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Constants
{
    public class ExceptionMessagesConstants
    {
        // Startup Company

        public const string EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has already been created with the name \"[{0}]\"";

        public const string NON_EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has not been created yet. You must set it in order to proceed";
    }
}
