namespace StartupCompanyManager.Utilities.Interpreter.Context
{
    public class StartupCompanyManagerOperationsContext
    {
        public StartupCompanyManagerOperationsContext(string input)
        {
            Input = input;
        }

        public string Input { get; set; } = null!;

        public string Output { get; set; } = null!;
    }
}