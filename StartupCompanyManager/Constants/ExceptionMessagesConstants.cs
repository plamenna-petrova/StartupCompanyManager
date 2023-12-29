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

        public const string EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has already been created with the name \"{0}\"";

        public const string NON_EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has not been created yet. You must set it in order to proceed";

        public const string EXISTING_DEPARTMENT_EXCEPTION_MESSAGE = "A department with the following name \"{0}\" already exists";

        public const string NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE = "A department with the following name \"{0}\" could not be found";

        public const string EXISTING_INVESTOR_EXCEPTION_MESSAGE = "An investor with the following name \"{0}\" already exists";

        public const string NON_EXISTING_INVESTOR_EXCEPTION_MESSAGE = "An investor with the following name \"{0}\" could not be found";

        // Commands

        public const string INVALID_STARTUP_COMPANY_MANAGER_OPERATION_EXCEPTION_MESSAGE = "Invalid operation expression. See the upper listed commands.";
    }
}
