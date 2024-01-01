namespace StartupCompanyManager.Constants
{
    public class ExceptionMessagesConstants
    {
        // Startup Company

        public const string EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has already been created with the name \"{0}\".";

        public const string NON_EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE = "The startup company has not been created yet. You must set it in order to proceed.";

        public const string EXISTING_DEPARTMENT_EXCEPTION_MESSAGE = "A department with the following name \"{0}\" already exists.";

        public const string NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE = "A department with the following name \"{0}\" could not be found.";

        public const string EXISTING_INVESTOR_EXCEPTION_MESSAGE = "An investor with the following name \"{0}\" already exists.";

        public const string NON_EXISTING_INVESTOR_EXCEPTION_MESSAGE = "An investor with the following name \"{0}\" could not be found.";

        public const string EXISTING_TEAM_EXCEPTION_MESSAGE = "A team with the following name \"{0}\" already exists.";

        public const string NON_EXISTING_TEAM_EXCEPTION_MESSAGE = "A team with the following name \"{0}\" could not be found.";

        public const string EXISTING_PROJECT_EXCEPTION_MESSAGE = "A project with the following name \"{0}\" already exists.";

        public const string NON_EXISTING_PROJECT_EXCEPTION_MESSAGE = "A project with the following name \"{0}\" could not be found.";

        public const string EXISTING_EMPLOYEE_EXCEPTION_MESSAGE = "An employee with the following data: First Name - {0}, Last Name - {1}, Birthdate - {2} already exists.";

        public const string NON_EXISTING_EMPLOYEE_EXCEPTION_MESSAGE = "An employee with the following name \"{0}\" could not be found.";

        public const string EXISTING_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE = "The department {0} has already head employee - {1}.";

        public const string NON_EXISTING_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE = "Head of department with the following name \"{0}\" could not be found.";

        public const string EXISTING_TEAM_LEAD_EXCEPTION_MESSAGE = "The team {0} has already lead employee - {1}.";

        public const string NON_EXISTING_TEAM_LEAD_EXCEPTION_MESSAGE = "Team lead with the following name \"{0}\" could not be found.";

        public const string EXISTING_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_EXCEPTION_MESSAGE = "The head of department {0} already has team lead subordinate {1}.";

        public const string EXISTING_TEAM_LEAD_EMPLOYEE_SUBORDINATE_EXCEPTION_MESSAGE = "The team lead {0} already has employee subordinate {1}";

        public const string EMPLOYEE_ALREADY_SUBORDINATE_OF_OTHER_TEAM_LEAD_EXCEPTION_MESAGE = "The following employee {0} is already a subordinate of another team lead {1}.";

        // Commands

        public const string INVALID_STARTUP_COMPANY_MANAGER_OPERATION_EXCEPTION_MESSAGE = "Invalid operation expression. See the upper listed commands.";

        public const string INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE = "Invalid count of arguments. Expected {0}, but found {1}.";

        public const string INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE = "The input must be of the following type {0}.";

        public const string INVALID_EMPLOYEE_TYPE_EXCEPTION_MESSAGE = "The following employee type does not exist {0}.";

        // Composite

        public const string ONLY_TEAM_LEADS_SUBORDINATES_ALLOWED_FOR_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE = "Cannot add a subordinate to head of department other than a team lead.";

        public const string HEAD_OF_DEPARTMENT_OR_TEAM_LEADS_NOT_ALOWED_FOR_TEAM_LEAD_SUBORDINATES_EXCEPTION_MESSAGE = "Cannot add a subordinate to team lead who is either head of department or team lead.";

        public const string CANNOT_ADD_ELEMENT_TO_LEAF_EXCEPTION_MESSAGE = "Cannot add subordinate to a {0}.";

        public const string CANNOT_REMOVE_ELEMENT_FROM_LEAF_EXCEPTION_MESSAGE = "Cannot remove subordinate from a {0}.";

        public const string DEPARTMENT_AND_TEAM_LEAD_TEAMS_MISMATCH_EXCEPTION_MESSAGE = "The department of the head employee {0} either doesn't have a team that matches to the team of the lead employee {1} or the team is not-existent.";

        public const string TEAM_LEAD_NOT_ASSIGNED_TEAM_EXCEPTION_MESSAGE = "The team lead doesn't have an assigned team.";
    }
}
