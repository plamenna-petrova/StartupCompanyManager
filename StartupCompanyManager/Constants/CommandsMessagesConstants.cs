namespace StartupCompanyManager.Constants
{
    public class CommandsMessagesConstants
    {
        // Concrete Command Patterns

        public const string ADD_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [YearOfEstablishment]";

        public const string ADD_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Funds]";

        public const string CHANGE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name | YearOfEstablishment] [Value]";

        public const string CHANGE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name | Funds] [Value]";

        public const string REMOVE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        public const string REMOVE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        // Success Messages

        public const string ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added department {0} to Startup Company \"{1}\".";

        public const string CHANGED_DEPARTMENT_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed department's {0} characteristic {1} to {2}.";

        public const string REMOVED_DEPARTMENT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed department {0} from Startup Company \"{1}\".";

        public const string ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added investor {0} to Startup Company \"{1}\".\nIncreased the company's capital from ${2} to ${3}.";

        public const string CHANGED_INVESTOR_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed investor's {0} characteristic {1} to {2}.";

        public const string INCREASED_STARTUP_COMPANY_CAPITAL_AFTER_INVESTOR_FUNDS_CHANGE = "Successfully increased the company's capital from {1} to {2}.";

        public const string REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed investor {0} from Startup Company \"{1}\".";
    }
}
