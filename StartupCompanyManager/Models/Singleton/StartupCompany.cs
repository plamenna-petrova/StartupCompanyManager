using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models.Singleton
{
    public class StartupCompany : BaseModel
    {
        private const string STARTUP_COMPANY_PRESENTATION_MESSAGE = "Hereby the startup company \"{0}\" is presented...";

        private const int MINIMUM_STARTUP_COMPANY_NAME_LENGTH = 2;

        private const int MAXIMUM_STARTUP_COMPANY_NAME_LENGTH = 30;

        private const decimal MINIMUM_STARTUP_COMPANY_CAPITAL = 50.0000M;

        private const decimal MAXIMUM_STARTUP_COMPANY_CAPITAL = 10000000M;

        private const int MINIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 8;

        private const int MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 50;

        private const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

        private const string STARTUP_COMPANY_EMAIL_ADDRESS_REGEX_PATTERN = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        private string name = null!;

        private decimal capital = default;

        private string email = null!;

        private string address = null!;

        private string phoneNumber = null!;

        private readonly StartupCompanyManagerValidationContext validationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy nullOrWhiteSpaceStringValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy stringLengthRangeValidationStrategy = new();

        private readonly DecimalValueIncorrectFormatConcreteValidationStrategy decimalValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly NumberRangeConcreteValidationStrategy numberRangeValidationStrategy = new();

        private readonly RegexPatternConcreteValidationStrategy regexPatternValidationStrategy = new();

        private static StartupCompany? startupCompanyInstance;

        private static readonly object lockObject = new();

        public StartupCompany(string name, decimal capital, string email, string address, string phoneNumber)
        {
            Name = name;
            Capital = capital;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get => name;
            private set
            {
                validationContext.SetValidationStrategy(nullOrWhiteSpaceStringValidationStrategy);

                if (validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(stringLengthRangeValidationStrategy);

                if (!validationContext.ValidateInput(
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

                validationContext.SetValidationStrategy(null!);
            }
        }

        public decimal Capital
        {
            get => capital;
            set
            {
                validationContext.SetValidationStrategy(decimalValueIncorrectFormatConcreteValidationStrategy);

                if (!validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_CAPITAL_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(numberRangeValidationStrategy);

                if (!validationContext.ValidateInput(value, MINIMUM_STARTUP_COMPANY_CAPITAL, MAXIMUM_STARTUP_COMPANY_CAPITAL))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.STARTUP_COMPANY_CAPITAL_NUMBER_RANGER_ERROR_MESSAGE, 
                            MINIMUM_STARTUP_COMPANY_CAPITAL, 
                            MAXIMUM_STARTUP_COMPANY_CAPITAL
                        )
                    );
                }

                capital = value;

                validationContext.SetValidationStrategy(null!);
            }
        }

        public string Email
        {
            get => email;
            set
            {
                validationContext.SetValidationStrategy(regexPatternValidationStrategy);

                if (!validationContext.ValidateInput(value, STARTUP_COMPANY_EMAIL_ADDRESS_REGEX_PATTERN))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_EMAIL_REGEX_PATTERN_ERROR_MESSAGE);
                }

                email = value;

                validationContext.SetValidationStrategy(null!);
            }
        }

        public string Address
        {
            get => address;
            set
            {
                validationContext.SetValidationStrategy(nullOrWhiteSpaceStringValidationStrategy);

                if (validationContext.ValidateInput(value)) 
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE);
                }

                validationContext.SetValidationStrategy(stringLengthRangeValidationStrategy);

                if (!validationContext.ValidateInput(
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

                validationContext.SetValidationStrategy(null!);
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                validationContext.SetValidationStrategy(regexPatternValidationStrategy);

                if (!validationContext.ValidateInput(value, STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN))
                {
                    throw new ArgumentException(ValidationConstants.STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN_ERROR_MESSAGE);
                }

                phoneNumber = value;

                validationContext.SetValidationStrategy(null!);
            }
        }

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        public ICollection<Investor> Investors { get; set; } = new HashSet<Investor>();

        public static StartupCompany StartupCompanyInstance
        {
            get
            {
                CheckIfInstanceIsCreated();
                return startupCompanyInstance!;
            }
        }

        public static StartupCompany CreateInstance(
            string name, decimal capital, string email, string address, string phoneNumber
        )
        {
            if (startupCompanyInstance == null)
            {
                lock (lockObject)
                {
                    if (startupCompanyInstance == null)
                    {
                        startupCompanyInstance = new StartupCompany(name, capital, email, address, phoneNumber);
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
            CheckIfInstanceIsCreated();

            startupCompanyInstance!.Name = newStartupCompanyName;

            return startupCompanyInstance;
        }

        private static void CheckIfInstanceIsCreated()
        {
            if (startupCompanyInstance is null)
            {
                throw new NonExistingStartupCompanyManagerEntityException(
                    ExceptionMessagesConstants.NON_EXISTING_STARTUP_COMPANY_EXCEPTION_MESSAGE
                );
            }
        }
    }
}
