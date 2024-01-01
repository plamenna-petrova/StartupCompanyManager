using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Infrastructure.Repositories.Contracts
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public void Assign(Employee employee, string assignmentOption, string filter);
    }
}
