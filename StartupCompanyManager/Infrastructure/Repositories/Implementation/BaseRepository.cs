using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public abstract class BaseRepository
    {
        public BaseRepository(StartupCompany startupCompany)
        {
            StartupCompany = startupCompany ?? throw new ArgumentNullException(nameof(startupCompany));
        }

        protected StartupCompany StartupCompany { get; set; }
    }
}
