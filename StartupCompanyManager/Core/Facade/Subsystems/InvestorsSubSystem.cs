using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Infrastructure.Repositories.Implementation;
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
            Investor foundInvestor = _investorRepository.GetByCondition(d => d.Name == name);

            bool doesInvestorExist = foundInvestor != null;

            if (doesInvestorExist)
            {
                string existingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingInvestorExceptionMessage);
            }

            Investor investorToAdd = new(name, funds);

            _investorRepository.Add(investorToAdd);

            return investorToAdd;
        }

        public void ChangeInvestorCharacteristic(string name, string characteristic, object value)
        {
            Investor investorToUpdate = _investorRepository.GetByCondition(d => d.Name == name);

            if (investorToUpdate == null)
            {
                string nonExistingInvestorExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_INVESTOR_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingInvestorExceptionMessage);
            }

            _investorRepository.Update(investorToUpdate, characteristic, value);
        }

        public void RemoveInvestor(string name)
        {
            Investor investorToRemove = _investorRepository.GetByCondition(d => d.Name == name);

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