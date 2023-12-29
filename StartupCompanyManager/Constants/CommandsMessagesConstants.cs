using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Constants
{
    public class CommandsMessagesConstants
    {
        public const string ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added department {0} to Startup Company {1}";

        public const string REMOVED_DEPARTMENT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed department {0} from Startup Company {1}";

        public const string ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added investor {0} to Startup Company {1}.\nIncreased the company's capital from ${2} to ${3}.";

        public const string REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed investor {0} from Startup Company {1}";
    }
}
