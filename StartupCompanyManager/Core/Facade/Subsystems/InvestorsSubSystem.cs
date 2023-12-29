using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class InvestorsSubSystem
    {
        private readonly IInvestorRepository _investorRepository;

        public InvestorsSubSystem(IInvestorRepository investorRepository)
        {
            _investorRepository = investorRepository;
        }

        public Investor AddInvestorToStartupCompany(string name, decimal funds)
        {
            Investor foundInvestor = _investorRepository.GetAllByCondition(d => d.Name == name).FirstOrDefault()!;

            bool doesInvestorExist = foundInvestor != null;

            if (doesInvestorExist)
            {
                string existingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingInvestorExceptionMessage);
            }

            Investor investorToAdd = new Investor(name, funds);

            _investorRepository.Add(investorToAdd);

            return investorToAdd;
        }

        public void RemoveInvestor(string name)
        {
            Investor investorToRemove = _investorRepository.GetAllByCondition(d => d.Name == name).FirstOrDefault()!;

            if (investorToRemove == null)
            {
                string nonExistingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingInvestorExceptionMessage);
            }

            _investorRepository.Remove(investorToRemove);
        }
    }
}