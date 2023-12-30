using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class InvestorRepository : BaseRepository, IInvestorRepository
    {
        public ICollection<Investor> GetAll()
        {
            return StartupCompany.Investors.ToList();
        }

        public Investor GetByCondition(Func<Investor, bool> filterExpression)
        {
            return StartupCompany.Investors.FirstOrDefault(filterExpression)!;
        }

        public ICollection<Investor> GetAllByCondition(Func<Investor, bool> filterExpression)
        {
            return StartupCompany.Investors.Where(filterExpression).ToList();
        }

        public void Add(Investor investor)
        {
            StartupCompany.Investors.Add(investor);
            StartupCompany.Capital += investor.Funds;
        }

        public void Update(Investor investor, string propertyName, object propertyValueToSet)
        {
            var investorPropertyInfo = investor.GetType().GetProperty(propertyName);
            var investorPropertyConversionType = investorPropertyInfo!.PropertyType;
            var convertedPropertyValueToSet = Convert.ChangeType(propertyValueToSet, investorPropertyConversionType);

            investor.GetType().GetProperty(propertyName)!.SetValue(investor, convertedPropertyValueToSet);

            if (propertyName == nameof(investor.Funds))
            {
                StartupCompany.Capital += (decimal) convertedPropertyValueToSet;
            }
        }

        public void Remove(Investor investor)
        {
            StartupCompany.Investors.Remove(investor);
        }

        public bool Exists(Investor investorToFind)
        {
            return StartupCompany.Investors.Contains(investorToFind);
        }
    }
}
