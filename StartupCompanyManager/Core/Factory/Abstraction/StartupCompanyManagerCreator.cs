namespace StartupCompanyManager.Core.Factory.Creator
{
    public abstract class StartupCompanyManagerCreator<TEntity> where TEntity : class
    {
        public abstract TEntity Create(params string[] entityCreationArguments);
    }
}
