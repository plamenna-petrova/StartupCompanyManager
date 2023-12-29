using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();

        TEntity GetByCondition(Func<TEntity, bool> filterExpression);

        ICollection<TEntity> GetAllByCondition(Func<TEntity, bool> filterExpression);

        void Add(TEntity entity);

        void Update(TEntity entity, string propertyName, object propertyValueToSet);

        void Remove(TEntity entity);

        bool Exists(TEntity entityToFind);
    }
}
