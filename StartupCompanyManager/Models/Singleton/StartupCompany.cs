using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Interfaces;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models.Singleton
{
    public class StartupCompany : BaseModel
    {
        private const string STARTUP_COMPANY_PRESENTATION_MESSAGE = "Hereby the startup company \"{0}\" is presented...";

        public const int MINIMUM_STARTUP_COMPANY_NAME_LENGTH = 2;

        public const int MAXIMUM_STARTUP_COMPANY_NAME_LENGTH = 30;

        public const decimal MINIMUM_STARTUP_COMPANY_CAPITAL = 50.0000M;

        public const decimal MAXIMUM_STARTUP_COMPANY_CAPITAL = 10000000;

        private const int MINIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 8;

        private const int MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH = 50;

        private const string STARTUP_COMPANY_PHONE_NUMBER_REGEX_PATTERN = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

        private const string STARTUP_COMPANY_EMAIL_ADDRESS_REGEX_PATTERN = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        private string name = null!;

        private decimal capital = default;

        private string email = null!;

        private string address = null!;

        private string phoneNumber = null!;

        private readonly ValidationContext validationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy nullOrWhiteSpaceStringValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy stringLengthRangeValidationStrategy = new();

        private readonly NumberRangeConcreteValidationStrategy numberRangeValidationStrategy = new();

        private readonly RegexPatternConcreteValidationStrategy regexPatternValidationStrategy = new();

        public string Name
        {
            get => name;
            private set
            {
                validationContext.SetValidationStrategy(nullOrWhiteSpaceStringValidationStrategy);

                if (validationContext.ValidateInput(value))
                {
                    throw new ArgumentException(
                        nameof(Name), ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_NAME_ERROR_MESSAGE
                    );
                }

                validationContext.SetValidationStrategy(stringLengthRangeValidationStrategy);

                if (!validationContext.ValidateInput(
                    value, MINIMUM_STARTUP_COMPANY_NAME_LENGTH, MAXIMUM_STARTUP_COMPANY_ADDRESS_LENGTH
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
                validationContext.SetValidationStrategy(numberRangeValidationStrategy);

                if (!validationContext.ValidateInput(value, MINIMUM_STARTUP_COMPANY_CAPITAL, MAXIMUM_STARTUP_COMPANY_CAPITAL))
                {
                    throw new ArgumentException(
                        nameof(Capital), ValidationConstants.STARTUP_COMPANY_CAPITAL_NUMBER_RANGER_ERROR_MESSAGE
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
                    throw new ArgumentException(
                        nameof(Address), ValidationConstants.NULL_OR_WHITE_SPACE_STARTUP_COMPANY_ADDRESS_ERROR_MESSAGE
                    );
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

        public void SetCompanyDetails(string name, decimal capital, string email, string address, string phoneNumber)
        {
            Name = name;
            Capital = capital;
            Email = email;
            Address = address; 
            PhoneNumber = phoneNumber;
        }
    }
}
