using StartupCompanyManager.Constants;
using StartupCompanyManager.Models.Abstraction;
using StartupCompanyManager.Models.Composite.Composites;
using StartupCompanyManager.Utilities.Strategy.ConcreteStrategies;
using StartupCompanyManager.Utilities.Strategy.Context;

namespace StartupCompanyManager.Models
{
    public class Team : BaseModel
    {
        private const int MINIMUM_TEAM_NAME_LENGTH = 3;

        private const int MAXIMUM_TEAM_NAME_LENGTH = 25;

        private string name = null!;

        private readonly StartupCompanyManagerValidationContext _startupCompanyManagerValidationContext = new();

        private readonly NullOrWhiteSpaceStringConcreteValidationStrategy _nullOrWhiteSpaceStringConcreteValidationStrategy = new();

        private readonly StringLengthRangeConcreteValidationStrategy _stringLengthRangeConcreteValidationStrategy = new();

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set 
            {
                _startupCompanyManagerValidationContext.SetValidationStrategy(_nullOrWhiteSpaceStringConcreteValidationStrategy);

                if (_startupCompanyManagerValidationContext.ValidateInput(value))
                {
                    throw new ArgumentException(ValidationConstants.NULL_OR_WHITE_SPACE_TEAM_NAME_ERROR_MESSAGE);
                }

                _startupCompanyManagerValidationContext.SetValidationStrategy(_stringLengthRangeConcreteValidationStrategy);

                if (!_startupCompanyManagerValidationContext.ValidateInput(
                    value, MINIMUM_TEAM_NAME_LENGTH, MAXIMUM_TEAM_NAME_LENGTH
                ))
                {
                    throw new ArgumentException(
                        string.Format(
                            ValidationConstants.TEAM_NAME_STRING_LENGTH_RANGE_ERROR_MESSAGE,
                            MINIMUM_TEAM_NAME_LENGTH,
                            MAXIMUM_TEAM_NAME_LENGTH
                        )
                    );
                }

                name = value;

                _startupCompanyManagerValidationContext.SetValidationStrategy(null!);
            }
        }

        public Project Project { get; set; } = null!;

        public Department Department { get; set; } = null!;

        public TeamLead TeamLead { get; set; } = null!;

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}