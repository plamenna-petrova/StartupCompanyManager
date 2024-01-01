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

        public Investor GetByCondition(Func<Investor, bool> entityFilterPredicate)
        {
            return StartupCompany.Investors.FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Investor> GetAllByCondition(Func<Investor, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Investors.Where(entitiesFilterPredicate).ToList();
        }

        public void Add(Investor investor, params object[] entityCreationArguments)
        {
            StartupCompany.Investors.Add(investor);
            StartupCompany.Capital += investor.Funds;
        }

        public void Update(Investor investor, string propertyName, object propertyValueToSet)
        {
            try
            {
                var investorPropertyInfo = investor.GetType().GetProperty(propertyName);
                var investorPropertyConversionType = investorPropertyInfo!.PropertyType;

                if (investorPropertyConversionType.IsPrimitive || investorPropertyConversionType == typeof(decimal) ||
                    investorPropertyConversionType == typeof(string)
                )
                {
                    var convertedInvestorPropertyValueToSet = Convert.ChangeType(propertyValueToSet, investorPropertyConversionType);
                    investor.GetType().GetProperty(propertyName)!.SetValue(investor, convertedInvestorPropertyValueToSet);

                    if (propertyName == nameof(investor.Funds))
                    {
                        StartupCompany.Capital += (decimal)convertedInvestorPropertyValueToSet;
                    }
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                            CommandsMessagesConstants.CHANGE_INVESTOR_CONCRETE_COMMAND_ARGUMENTS_PATTERN
                        )
                    );
                }
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.InnerException.Message);
                }
            }
        }

        public void Remove(Investor investor, params object[] entityDeletionArguments)
        {
            StartupCompany.Investors.Remove(investor);
        }

        public bool Exists(Investor investorToFind, params object[] entityExistenceArguments)
        {
            return StartupCompany.Investors.Contains(investorToFind);
        }
    }
}
