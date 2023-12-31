namespace StartupCompanyManager.Constants
{
    public class ValidationConstants
    {
        // Startup Company

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE = "The startup company's name cannot be empty or consisting only of whitespaces.";

        public const string STARTUP_COMPANY_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's name must be between {0} and {1} characters long.";

        public const string NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE = "The startup company's address cannot be empty or consisting only of whitespaces.";

        public const string STARTUP_COMPANY_CAPITAL_INCORRECT_FORMAT_ERROR_MESSAGE = "The startup company's capital is not in the correct format.";

        public const string STARTUP_COMPANY_CAPITAL_NUMBER_RANGE_ERROR_MESSAGE = "The startup company's capital must be between ${0} and ${1}.";

        public const string STARTUP_COMPANY_ADDRESS_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The startup company's address must be between {0} and {1} characters long.";

        public const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's phone number is not in the correct format.";

        public const string STARTUP_COMPANY_EMAIL_REGEX_PATTERN_ERROR_MESSAGE = "The startup company's email is not in the correct format.";

        // Department

        public const string NULL_OR_WHITE_SPACE_DEPARTMENT_NAME_ERROR_MESSAGE = "The department's name cannot be empty or consisting only of whitespaces.";

        public const string DEPARTMENT_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The department's name must be between {0} and {1} characters long.";

        public const string DEPARTMENT_YEAR_OF_ESTABLISHMENT_INCORRECT_FORMAT_ERROR_MESSAGE = "The department's year of establishment is not in the correct format.";

        public const string DEPARTMENT_YEAR_OF_ESTABLISHMENT_NUMBER_RANGE_ERROR_MESSAGE = "The department's year of establishment must be between {0} and {1}.";

        // Investor

        public const string NULL_OR_WHITE_SPACE_INVESTOR_NAME_ERROR_MESSAGE = "The investor's name cannot be empty or consisting only of whitespaces.";

        public const string INVESTOR_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The investor's name must be between {0} and {1} characters long.";

        public const string INVESTOR_FUNDS_INCORRECT_FORMAT_ERROR_MESSAGE = "The investor's funds are not in the correct format.";

        public const string INVESTOR_FUNDS_MINIMUM_VALUE_ERROR_MESSAGE = "The investor's funds must be at least {0}.";

        // Project

        public const string NULL_OR_WHITE_SPACE_PROJECT_NAME_ERROR_MESSAGE = "The project's name cannot be empty or consisting only of whitespaces.";

        public const string PROJECT_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The project's name must be between {0} and {1} characters long.";

        public const string PROJECT_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE = "The project's assignment date is not in the correct format.";

        public const string PROJECT_DEADLINE_INCORRECT_FORMAT_ERROR_MESSAGE = "The project's deadline is not in the correct format.";

        public const string PROJECT_EXECUTION_DAYS_ERROR_MESSAGE = "The project's deadline must be set at least {0} days apart from its assignment date.";

        // Task

        public const string NULL_OR_WHITE_SPACE_TASK_NAME_ERROR_MESSAGE = "The task's name cannot be empty or consisting only of whitespaces.";

        public const string TASK_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The task's name must be between {0} and {1} characters long.";

        public const string TASK_PRIORITY_INCORRECT_OPTION_ERROR_MESAGE = "The task's priority must correspond to an option from the following list {0}.";

        public const string TASK_STATUS_INCORRECT_OPTION_ERROR_MESSAGE = "The task's status must correspond to an option from the following list {0}.";

        public const string TASK_ASSIGNMENT_DATE_INCORRECT_FORMAT_ERROR_MESSAGE = "The task's assignment date is not in the correct format.";

        public const string TASK_ASSIGNMENT_DATE_EARLIER_THAN_PROJECT_START_ERROR_MESSAGE = "The task's assignment date is set earlier than project's start {0}";

        public const string TASK_DUE_DATE_INCORRECT_FORMAT_ERROR_MESSAGE = "The task's due date is not in the correct format.";

        public const string TASK_DUE_DATE_AFTER_PROJECT_END_ERROR_MESSAGE = "The task's due date is set after the project's end {0}";

        public const string TASK_EXECUTION_DAYS_ERROR_MESSAGE = "The task's due date must be set at least {0} days from its assignment date.";

        // Team

        public const string NULL_OR_WHITE_SPACE_TEAM_NAME_ERROR_MESSAGE = "The team's name cannot be empty or consisting only of whitespaces";

        public const string TEAM_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The team's name must be between {0} and {1} characters long.";

        // Employee

        public const string NULL_OR_WHITE_SPACE_EMPLOYEE_FIRST_NAME_ERROR_MESSAGE = "The employee's first name cannot be empty or consisting only of whitespaces.";

        public const string EMPLOYEE_FIRST_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The employee's first name must be between {0} and {1} characters long.";

        public const string NULL_OR_WHITE_SPACE_EMPLOYEE_LAST_NAME_ERROR_MESSAGE = "The employee's last name cannot be empty or consisting only of whitespaces.";

        public const string EMPLOYEE_LAST_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The employee's last name must be between {0} and {1} characters long.";

        public const string NULL_OR_WHITE_SPACE_EMPLOYEE_POSITION_ERROR_MESSAGE = "The employee's position cannot be empty or consisting only of whitespaces.";

        public const string EMPLOYEE_POSITION_STRING_LENGTH_RANGE_ERROR_MESSAGE = "The employee's position must be between {0} and {1} characters long.";

        public const string EMPLOYEE_MONTHLY_SALARY_INCORRECT_FORMAT_ERROR_MESSAGE = "The employee's salary is not in the correct format.";

        public const string EMPLOYEE_MONTHLY_SALARY_NUMBER_RANGE_ERROR_MESSAGE = "The employee's salary must be between ${0} and ${1}.";

        public const string EMPLOYEE_YEARS_OF_WORK_EXPERIENCE_INCORRECT_FORMAT_ERROR_MESSAGE = "The employee's years of work experience are not in the correct format.";

        public const string EMPLOYEE_YEARS_OF_WORK_EXPERIENCE_MINIMUM_VALUE_ERROR_MESSAGE = "The investor's funds must be at least {0}.";

        public const string EMPLOYEE_RATING_INCORRECT_FORMAT_ERROR_MESSAGE = "The employee's rating is not in the correct format.";

        public const string EMPLOYEE_RATING_NUMBER_RANGE_ERROR_MESSAGE = "The employee's rating must be between {0} and {1}.";

        public const string EMPLOYEE_BIRTH_DATE_INCORRECT_FORMAT_ERROR_MESSAGE = "The employee's birthday is not in the correct format.";
    }
}