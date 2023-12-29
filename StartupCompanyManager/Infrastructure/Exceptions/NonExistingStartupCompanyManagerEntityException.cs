namespace StartupCompanyManager.Infrastructure.Exceptions
{
    public class NonExistingStartupCompanyManagerEntityException : Exception
    {
        public NonExistingStartupCompanyManagerEntityException() 
        {
            
        }

        public NonExistingStartupCompanyManagerEntityException(string message) : base(message)
        {
            
        }
    }
}
