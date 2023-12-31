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

        public const string EXISTING_EMPLOYEE_EXCEPTION_MESSAGE = "An with the following data: First Name - \"{0}\", Last Name - \"{1}\", Birthdate - \"{2}\" already exists.";

        public const string NON_EXISTING_EMPLOYEE_EXCEPTION_MESSAGE = "An employee with the following name \"{0}\" could not be found.";

        // Commands

        public const string INVALID_STARTUP_COMPANY_MANAGER_OPERATION_EXCEPTION_MESSAGE = "Invalid operation expression. See the upper listed commands.";

        public const string INVALID_COUNT_OF_ARGUMENTS_EXCEPTION_MESSAGE = "Invalid count of arguments. Expected {0}, but found {1}.";

        public const string INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE = "The input must be of the following type {0}.";

        public const string INVALID_EMPLOYEE_TYPE_EXCEPTION_MESSAGE = "The following employee type does not exist {0}.";

        // Composite

        public const string CANNOT_ADD_ELEMENT_TO_LEAF_EXCEPTION_MESSAGE = "Cannot add new element to a {0}.";

        public const string CANNOT_REMOVE_ELEMENT_FROM_LEAF_EXCEPTION_MESSAGE = "Cannot remove element from a {0}.";
    }
}
