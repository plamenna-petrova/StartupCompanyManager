using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;
using System.Text;

namespace StartupCompanyManager.Models.Singleton
{
    public class StartupCompany : BaseModel
    {
        private const string STARTUP_COMPANY_PRESENTATION_MESSAGE = "Hereby the startup company \"{0}\" is presented...";

        private const int MINIMUM_STARTUP_COMPANY_NAME_LENGTH = 2;

        private const int MAXIMUM_STARTUP_COMPANY_NAME_LENGTH = 30;

        private const decimal MINIMUM_STARTUP_COMPANY_CAPITAL = 5000.00M;

        private const decimal MAXIMUM_STARTUP_COMPANY_CAPITAL = 10000000M;

        private const int EARLIEST_ALLOWED_STARTUP_COMPANY_YEAR_OF_ESTABLISHMENT = 2012;

        private const int MINIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 8;

        private const int MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 50;

        private const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

        private const string STARTUP_COMPANY_EMAIL_ADDRESS_REGEX_PATTERN = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        private const string STARTUP_COMPANY_INVESTORS_DETAILS = "Investors: ";

        private const string NO_STARTUP_COMPANY_INVESTORS_DETAILS = "There are currently no investors registered under: \"{0}\"";

        private const string STARTUP_COMPANY_DEPARTMENTS_DETAILS = "Departments: ";

        private const string NO_ASSIGNED_HEAD_OF_DEPARTMENT_DETAILS = "No head of department assigned";

        private const string DEPARTMENT_EMPLOYEES_DETAILS = "Employees: ";

        private const string NO_STARTUP_COMPANY_DEPARTMENTS_DETAILS = "There are currently no departments registered under: \"{0}\"";

        private string name = null!;

        private decimal capital = default;

        private int yearOfEstablishment = default!;

        private string email = null!;

        private string address = null!;

        private string phoneNumber = null!;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly IntegerValueIncorrectFormatConcreteValidationStrategy _integerValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly IntegersNumberRangeConcreteValidationStrategy _integersRangeConcreteValidationStrategy = new();

        private readonly DecimalValueIncorrectFormatConcreteValidationStrategy _decimalValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly DecimalsNumberRangeConcreteValidationStrategy _decimalsNumberRangeConcreteValidationStrategy = new();

        private readonly RegexPatternConcreteValidationStrategy _regexPatternConcreteValidationStrategy = new();

        private static StartupCompany? startupCompanyInstance;

        private static readonly object lockObject = new();

        public StartupCompany(string name, decimal capital, int yearOfEstablishment, string email, string address, string phoneNumber)
        {
            Name = name;
            Capital = capital;
            YearOfEstablishment = yearOfEstablishment;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get => name;
            private set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_STARTUP_COMPANY_NAME_LENGTH, MAXIMUM_STARTUP_COMPANY_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.STARTUP_COMPANY_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE, 
                            MINIMUM_STARTUP_COMPANY_NAME_LENGTH, 
                            MAXIMUM_STARTUP_COMPANY_NAME_LENGTH
                        )
                    );
                }

                name = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public decimal Capital
        {
            get => capital;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_decimalValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_CAPITAL_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_decimalsNumberRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_STARTUP_COMPANY_CAPITAL, MAXIMUM_STARTUP_COMPANY_CAPITAL
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.STARTUP_COMPANY_CAPITAL_NUMBER_RANGE_ERROR_MESSAGE, 
                            MINIMUM_STARTUP_COMPANY_CAPITAL, 
                            MAXIMUM_STARTUP_COMPANY_CAPITAL
                        )
                    );
                }

                capital = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public int YearOfEstablishment
        {
            get => yearOfEstablishment;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_integerValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_YEAR_OF_ESTABLISHMENT_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_integersRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, EARLIEST_ALLOWED_STARTUP_COMPANY_YEAR_OF_ESTABLISHMENT, DateTime.Today.Year
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.STARTUP_COMPANY_YEAR_OF_ESTABLISHMENT_NUMBER_RANGE_ERROR_MESSAGE,
                            EARLIEST_ALLOWED_STARTUP_COMPANY_YEAR_OF_ESTABLISHMENT,
                            DateTime.Today.Year
                        )
                    );
                }

                yearOfEstablishment = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public string Email
        {
            get => email;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_regexPatternConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, STARTUP_COMPANY_EMAIL_ADDRESS_REGEX_PATTERN))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_EMAIL_REGEX_PATTERN_ERROR_MESSAGE);
                }

                email = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public string Address
        {
            get => address;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value)) 
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_STARTUP_COMPANY_ADDRESS_LENGTH, MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.STARTUP_COMPANY_ADDRESS_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_STARTUP_COMPANY_ADDRESS_LENGTH,
                            MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH
                        )
                    );
                }

                address = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_regexPatternConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN_ERROR_MESSAGE);
                }

                phoneNumber = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        public ICollection<Investor> Investors { get; set; } = new HashSet<Investor>();

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public static StartupCompany StartupCompanyInstance
        {
            get
            {
                CheckIfStartupCompanyInstanceIsCreated();
                return startupCompanyInstance!;
            }
        }

        public static StartupCompany CreateInstance(
            string name, decimal capital, int yearOfEstablishment, string email, string address, string phoneNumber
        )
        {
            if (startupCompanyInstance == null)
            {
                lock (lockObject)
                {
                    if (startupCompanyInstance == null)
                    {
                        startupCompanyInstance = new StartupCompany(name, capital, yearOfEstablishment, email, address, phoneNumber);
                        return startupCompanyInstance;
                    }
                }
            }

            throw new ExistingStartupCompanyManagerEntityException(
                string.Format(
                    ExceptionMessagesConstants.EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE,
                    startupCompanyInstance.Name
                )
            );
        }

        public static StartupCompany ChangeName(string newStartupCompanyName)
        {
            CheckIfStartupCompanyInstanceIsCreated();

            startupCompanyInstance!.Name = newStartupCompanyName;

            return startupCompanyInstance;
        }

        private static void CheckIfStartupCompanyInstanceIsCreated()
        {
            if (startupCompanyInstance is null)
            {
                throw new NonExistingStartupCompanyManagerEntityException(
                    ExceptionMessagesConstants.NON_EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE
                );
            }
        }

        public override string ToString()
        {
            StringBuilder startupCompanyInfoStringBuilder = new();

            startupCompanyInfoStringBuilder.AppendLine();
            startupCompanyInfoStringBuilder.AppendLine(string.Format(STARTUP_COMPANY_PRESENTATION_MESSAGE, Name));
            startupCompanyInfoStringBuilder.AppendLine();
            startupCompanyInfoStringBuilder.AppendLine(STARTUP_COMPANY_INVESTORS_DETAILS);

            if (Investors.Any())
            {
                foreach (var investor in Investors)
                {
                    startupCompanyInfoStringBuilder.AppendLine($"{new string(' ', 2)}{investor.ToString()}");
                }
            }
            else
            {
                startupCompanyInfoStringBuilder.AppendLine(string.Format(NO_STARTUP_COMPANY_INVESTORS_DETAILS, Name));
            }

            startupCompanyInfoStringBuilder.AppendLine(STARTUP_COMPANY_DEPARTMENTS_DETAILS);

            if (Departments.Any())
            {
                foreach (var department in Departments)
                {
                    startupCompanyInfoStringBuilder.AppendLine($"{new string(' ', 2)}{department.ToString()}");

                    if (department.HeadOfDepartment != null)
                    {
                        startupCompanyInfoStringBuilder.AppendLine(DEPARTMENT_EMPLOYEES_DETAILS);
                        startupCompanyInfoStringBuilder.AppendLine($"{new string(' ', 4)}{department.HeadOfDepartment.GetHierarchicalLevel(2)}");
                    }
                    else
                    {
                        startupCompanyInfoStringBuilder.AppendLine($"{new string(' ', 2)}{NO_ASSIGNED_HEAD_OF_DEPARTMENT_DETAILS}");
                    }
                }
            }
            else
            {
                startupCompanyInfoStringBuilder.AppendLine($"{string.Format(NO_STARTUP_COMPANY_DEPARTMENTS_DETAILS, Name)}");
            }

            startupCompanyInfoStringBuilder.AppendLine();

            return startupCompanyInfoStringBuilder.ToString();
        }
    }
}
