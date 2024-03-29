﻿using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models.Composite.Component
{
    public abstract class Employee : BaseModel
    {
        private const int MINIMUM_EMPLOYEE_FIRST_NAME_LENGTH = 1;

        private const int MAXIMUM_EMPLOYEE_FIRST_NAME_LENGTH = 35;

        private const int MINIMUM_EMPLOYEE_LAST_NAME_LENGTH = 1;

        private const int MAXIMUM_EMPLOYEE_LAST_NAME_LENGTH = 35;

        private const int MINIMUM_EMPLOYEE_POSITION_LENGTH = 3;

        private const int MAXIMUM_EMPLOYEE_POSITION_LENGTH = 50;

        private const decimal MINIMUM_EMPLOYEE_MONTHLY_SALARY = 1000.00M;

        private const decimal MAXIMUM_EMPLOYEE_MONTHLY_SALARY = 30000.00M;

        private const int MINIMUM_EMPLOYEE_YEARS_OF_WORK_EXPERIENCE = 1;

        private const int MINIMUM_EMPLOYEE_RATING = 1;

        private const int MAXIMUM_EMPLOYEE_RATING = 10;

        private string firstName = null!;

        private string lastName = null!;

        private string position = null!;

        private decimal monthlySalary = default;

        private int yearsOfWorkExperience = default;

        private DateTime birthDate = default;

        private int rating = default;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        private readonly DecimalValueIncorrectFormatConcreteValidationStrategy _decimalValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly IntegerValueIncorrectFormatConcreteValidationStrategy _integerValueIncorrectFormatConcreteValidationStrategy = new();

        private readonly DecimalsNumberRangeConcreteValidationStrategy _decimalsNumberRangeConcreteValidationStrategy = new();

        private readonly IntegersNumberRangeConcreteValidationStrategy _integersNumberRangeConcreteValidationStrategy = new();

        private readonly MinIntegerNumberValueConcreteValidationStrategy _minIntegerNumberConcreteValidationStrategy = new();

        public Employee(string firstName, string lastName, string position, decimal monthlySalary, int yearsOfWorkExperience, DateTime birthDate, int rating)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            MonthlySalary = monthlySalary;
            YearsOfWorkExperience = yearsOfWorkExperience;
            BirthDate = birthDate;
            Rating = rating;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_EMPLOYEE_FIRST_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_EMPLOYEE_FIRST_NAME_LENGTH, MAXIMUM_EMPLOYEE_FIRST_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_FIRST_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_FIRST_NAME_LENGTH,
                            MAXIMUM_EMPLOYEE_FIRST_NAME_LENGTH
                        )
                    );
                }

                firstName = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_EMPLOYEE_LAST_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_EMPLOYEE_LAST_NAME_LENGTH, MAXIMUM_EMPLOYEE_LAST_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_LAST_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_LAST_NAME_LENGTH,
                            MAXIMUM_EMPLOYEE_LAST_NAME_LENGTH
                        )
                    );
                }

                lastName = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string Position
        {
            get => position;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_EMPLOYEE_POSITION_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_EMPLOYEE_POSITION_LENGTH, MAXIMUM_EMPLOYEE_POSITION_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_POSITION_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_POSITION_LENGTH,
                            MAXIMUM_EMPLOYEE_POSITION_LENGTH
                        )
                    );
                }

                position = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public decimal MonthlySalary
        {
            get => monthlySalary;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_decimalValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.EMPLOYEE_MONTHLY_SALARY_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_decimalsNumberRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_EMPLOYEE_MONTHLY_SALARY, MAXIMUM_EMPLOYEE_MONTHLY_SALARY
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_MONTHLY_SALARY_NUMBER_RANGE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_MONTHLY_SALARY,
                            MAXIMUM_EMPLOYEE_MONTHLY_SALARY
                        )
                    );
                }

                monthlySalary = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public int YearsOfWorkExperience
        {
            get => yearsOfWorkExperience;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_integerValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.EMPLOYEE_YEARS_OF_WORK_EXPERIENCE_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_minIntegerNumberConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value, MINIMUM_EMPLOYEE_YEARS_OF_WORK_EXPERIENCE))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_YEARS_OF_WORK_EXPERIENCE_MINIMUM_VALUE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_YEARS_OF_WORK_EXPERIENCE
                        )
                    );
                }

                yearsOfWorkExperience = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public int Rating
        {
            get => rating;
            set
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_integerValueIncorrectFormatConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.EMPLOYEE_RATING_INCORRECT_FORMAT_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_integersNumberRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_EMPLOYEE_RATING, MAXIMUM_EMPLOYEE_RATING
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.EMPLOYEE_RATING_NUMBER_RANGE_ERROR_MESSAGE,
                            MINIMUM_EMPLOYEE_RATING,
                            MAXIMUM_EMPLOYEE_RATING
                        )
                    );
                }

                rating = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public Team Team { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

        public abstract ICollection<Employee> Employees { get; set; }

        public abstract void Add(Employee employee);

        public abstract void Remove(Employee employee);

        public abstract string GetHierarchicalLevel(int depthIndicator);
    }
}
