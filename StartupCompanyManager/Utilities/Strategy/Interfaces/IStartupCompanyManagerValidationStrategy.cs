namespace StartupCompanyManager.Utilities.Strategy.Interfaces
{
    public interface IStartupCompanyManagerValidationStrategy
    {
        bool ValidateInput(object input, params object[] validationArguments);
    }
}