namespace StartupCompanyManager.Infrastructure.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();

        TEntity GetByCondition(Func<TEntity, bool> entityFilterDelegate);

        ICollection<TEntity> GetAllByCondition(Func<TEntity, bool> entitiesFilterDelegate);

        void Add(TEntity entity, params object[] entityCreationArguments);

        void Update(TEntity entity, string propertyName, object propertyValueToSet);

        void Remove(TEntity entity, params object[] entityDeletionArguments);

        bool Exists(TEntity entityToFind, params object[] entityExistenceArguments);
    }
}
