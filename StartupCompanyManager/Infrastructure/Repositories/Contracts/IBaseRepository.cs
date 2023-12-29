using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();

        ICollection<TEntity> GetAllByCondition(Func<TEntity, bool> filterExpression);

        void Add(TEntity entity);

        void Update(TEntity entity, string propertyName, object propertyValueToSet);

        void Delete(TEntity entity);

        bool Exists(TEntity entityToFind);
    }
}
