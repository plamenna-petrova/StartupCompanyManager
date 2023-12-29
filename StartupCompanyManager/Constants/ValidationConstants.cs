using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Constants
{
    public class ValidationConstants
    {
        // Startup Company

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE = "The startup company's name cannot be empty or consisting only of whitespaces.";

        public const string STARTUP_COMPANY_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's name must be between {0} and {1} characters long.";

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE = "The startup company's address cannot be empty or consisting only of whitespaces";

        public const string STARTUP_COMPANY_CAPITAL_NUMBER_RANGER_ERROR_MESSAGE = "The startup company's capital must be between ${0} and ${1}";

        public const string STARTUP_COMPANY_ADDRESS_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's address must be between {0} and {1} characters long.";

        public const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's phone number is not in the correct format";

        public const string STARTUP_COMPANY_EMAIL_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's email is not in the correct format";

        public const string STARTUP_COMPANY_WEBSITE_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's website is not in the correct format";
    }
}