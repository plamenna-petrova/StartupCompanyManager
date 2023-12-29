using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class InvestorRepository : BaseRepository, IInvestorRepository
    {
        public InvestorRepository(StartupCompany startupCompany) : base(startupCompany)
        {

        }

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
            StartupCompany.Capital += investor.Funds;
            StartupCompany.Investors.Add(investor);
        }

        public void Update(Investor investor, string propertyName, object propertyValueToSet)
        {
            investor.GetType().GetProperty(propertyName)!.SetValue(investor, propertyValueToSet);
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
