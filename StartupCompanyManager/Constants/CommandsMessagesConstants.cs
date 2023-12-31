namespace StartupCompanyManager.Constants
{
    public class CommandsMessagesConstants
    {
        // Concrete Command Patterns

        public const string ADD_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Year Of Establishment]";

        public const string ADD_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Funds]";

        public const string CHANGE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name | Year Of Establishment] [Value]";

        public const string CHANGE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name | Funds] [Value]";

        public const string REMOVE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        public const string REMOVE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        public const string ADD_TEAM_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Department]";

        public const string CHANGE_TEAM_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name | Team Lead] [Value]";

        public const string REMOVE_TEAM_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        public const string ADD_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Assignment Date] [Deadline] [Team]";

        public const string CHANGE_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name] [Name] [Value]";

        public const string REMOVE_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[Name]";

        public const string ADD_EMPLOYEE_CONCRETE_COMMAND_ARGUMENTS_PATTERN = "[HeadOfDepartment | TeamLead | Officer | SoftwareDeveloper | Specialist | Tester] [First Name] [Last Name] [Monthly Salary] [Years Of Work Experience] [Birth Date] [Rating]";

        // Success Messages

        public const string ADDED_DEPARTMENT_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added department {0} to Startup Company \"{1}\".";

        public const string CHANGED_DEPARTMENT_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed department's {0} characteristic {1} to {2}.";

        public const string REMOVED_DEPARTMENT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed department {0} from Startup Company \"{1}\".";

        public const string ADDED_INVESTOR_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added investor {0} to Startup Company \"{1}\".\nIncreased the company's capital from ${2} to ${3}.";

        public const string CHANGED_INVESTOR_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed investor's {0} characteristic {1} to {2}.";

        public const string INCREASED_STARTUP_COMPANY_CAPITAL_AFTER_INVESTOR_FUNDS_CHANGE = "Successfully increased the company's capital from {1} to {2}.";

        public const string REMOVED_INVESTOR_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed investor {0} from Startup Company \"{1}\".";

        public const string ADDED_TEAM_TO_DEPARTMENT_SUCCESS_MESSAGE = "Successfully added team {0} to department {1}.";

        public const string CHANGED_TEAM_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed team's {0} characteristic {1} to {2}.";

        public const string REMOVED_TEAM_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed team {0} from Startup Company \"{1}\".";

        public const string ADDED_PROJECT_TO_TEAM_SUCCESS_MESSAGE = "Successfully added project {0} to team {1}.";

        public const string CHANGED_PROJECT_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed project's {0} characteristic {1} to {2}.";

        public const string REMOVED_PROJECT_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed project {0} from Startup Company \"{1}\".";

        public const string ADDED_EMPLOYEE_TO_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully added employee {0} to Startup Company \"{1}\".";

        public const string CHANGED_EMPLOYEE_OF_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully changed employee's {0} characteristic {1} to {2}.";

        public const string REMOVED_EMPLOYEE_FROM_STARTUP_COMPANY_SUCCESS_MESSAGE = "Successfully removed employee {0} from Startup Company \"{1}\".";
    }
}
