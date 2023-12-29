using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Facade.Subsystems
{
    public class InvestorsSubSystem
    {
        private IStartupCompany startupCompany;

        public InvestorsSubSystem(IStartupCompany startupCompany)
        {
            this.startupCompany = startupCompany;
        }

        public Investor AddInvestorToStartupCompany(string name, decimal funds)
        {
            Investor foundInvestor = FindInvestor(name);

            bool doesInvestorExist = foundInvestor != null;

            if (doesInvestorExist)
            {
                string existingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingInvestorExceptionMessage);
            }

            Investor investorToAdd = new Investor(name, funds);

            startupCompany.Investors.Add(investorToAdd);

            startupCompany.Capital += investorToAdd.Funds;

            return investorToAdd;
        }

        public void RemoveInvestor(string name)
        {
            Investor investorToRemove = FindInvestor(name);

            if (investorToRemove == null)
            {
                string nonExistingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingInvestorExceptionMessage);
            }

            startupCompany.Investors.Remove(investorToRemove);
        }

        private Investor FindInvestor(string name) => 
            startupCompany.Investors.FirstOrDefault(i => i.Name == name);
    }
}