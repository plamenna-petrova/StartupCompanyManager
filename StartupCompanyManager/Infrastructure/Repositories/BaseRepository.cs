using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        public BaseRepository()
        {
            StartupCompanyManagerCollection = new List<TEntity>();
        }

        protected ICollection<TEntity> StartupCompanyManagerCollection { get; set; }

        public ICollection<TEntity> GetAll()
        {
            return StartupCompanyManagerCollection.ToList();
        }

        public ICollection<TEntity> GetAllByCondition(Func<TEntity, bool> filterExpression)
        {
            return StartupCompanyManagerCollection.Where(filterExpression).ToList();
        }

        public void Add(TEntity entity)
        {
            StartupCompanyManagerCollection.Add(entity);
        }

        public void Update(TEntity entity, string propertyName, object propertyValueToSet)
        {
            entity.GetType().GetProperty(propertyName).SetValue(entity, propertyValueToSet);
        }

        public void Delete(TEntity entity)
        {
            StartupCompanyManagerCollection.Remove(entity);
        }

        public bool Exists(TEntity entityToFind)
        {
            return StartupCompanyManagerCollection.Contains(entityToFind);
        }
    }
}
