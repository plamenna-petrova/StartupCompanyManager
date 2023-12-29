namespace StartupCompanyManager.Utilities.Strategy.Interfaces
{
    public interface IValidationStrategy
    {
        bool ValidateInput(object input, params object[] validationArguments);
    }
}