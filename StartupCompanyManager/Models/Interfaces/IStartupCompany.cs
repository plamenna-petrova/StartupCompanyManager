using StartupCompanyManager.Core.Facade.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models.Interfaces
{
    public interface IStartupCompany
    {
        string Name { get; }

        decimal Capital { get; set; }

        ICollection<Department> Departments { get; }

        ICollection<Investor> Investors { get; }

        StartupCompanyManagerFacade StartupCompanyManagerFacade { get; }
    }
}
