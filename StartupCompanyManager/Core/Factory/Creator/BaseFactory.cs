using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Factory.Creator
{
    public abstract class BaseFactory<TEntity> where TEntity : class
    {
        public abstract TEntity Create(params string[] entityCreationArguments);
    }
}
