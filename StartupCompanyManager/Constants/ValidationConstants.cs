namespace StartupCompanyManager.Constants
{
    public class ValidationConstants
    {
        // Startup Company

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE = "The startup company's name cannot be empty or consisting only of whitespaces.";

        public const string STARTUP_COMPANY_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's name must be between {0} and {1} characters long.";

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE = "The startup company's address cannot be empty or consisting only of whitespaces.";

        public const string STARTUP_COMPANY_CAPITAL_INCORRECT_FORMAT_ERROR_MESSAGE = "The startup company's capital is not in the correct format.";

        public const string STARTUP_COMPANY_CAPITAL_NUMBER_RANGER_ERROR_MESSAGE = "The startup company's capital must be between ${0} and ${1}.";

        public const string STARTUP_COMPANY_ADDRESS_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's address must be between {0} and {1} characters long.";

        public const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's phone number is not in the correct format.";

        public const string STARTUP_COMPANY_EMAIL_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's email is not in the correct format.";

        // Department

        public const string NULL_OR_WHITE_SPACE_DEPARTMENT_NAME_ERROR_MESSAGE = "The department's name cannot be empty or consisting only of whitespaces.";

        public const string DEPARTMENT_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The department's name must be between {0} and {1} characters long.";

        public const string DEPARTMENT_YEAR_OF_ESTABLISHMENT_INCORRECT_FORMAT_ERROR_MESSAGE = "The department's year of establishment is not in the correct format";

        public const string DEPARTMENT_YEAR_OF_ESTABLISHMENT_NUMBER_RANGE_ERROR_MESSAGE = "The department's year of establishment must be between {0} and {1}";

        // Investor

        public const string NULL_OR_WHITE_SPACE_INVESTOR_NAME_ERROR_MESSAGE = "The investor's name cannot be empty or consisting only of whitespaces.";

        public const string INVESTOR_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The investor's name must be between {0} and {1} characters long.";

        public const string INVESTOR_FUNDS_INCORRECT_FORMAT_ERROR_MESSAGE = "The investor's funds are not in the correct format";

        public const string INVESTOR_FUNDS_MINIMUM_VALUE_ERROR_MESSAGE = "The investor's funds must be at least {0}";
    }
}