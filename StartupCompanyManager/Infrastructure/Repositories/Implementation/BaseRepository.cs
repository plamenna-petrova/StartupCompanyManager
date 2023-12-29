using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public abstract class BaseRepository
    {
        protected StartupCompany StartupCompany { get; set; } = StartupCompany.StartupCompanyInstance;
    }
}
