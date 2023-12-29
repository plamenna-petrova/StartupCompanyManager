using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade.SubSystems;
using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Facade
{
    public class StartupCompanyManagerFacade
    {
        private readonly IStartupCompany startupCompany;

        private DepartmentsSubSystem departmentsSubSystem;

        private InvestorsSubSystem investorsSubSystem;

        public StartupCompanyManagerFacade(IStartupCompany startupCompany)
        {
            this.startupCompany = startupCompany;
            departmentsSubSystem = new DepartmentsSubSystem(startupCompany);
            investorsSubSystem = new InvestorsSubSystem(startupCompany);
        }

        public void ExecuteDepartmentRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] departmentSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    departmentsSubSystem.AddDepartmentToStartupCompany(
                        (string)departmentSubsystemOperationArguments[0], int.Parse((string)departmentSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    departmentsSubSystem.RemoveDepartment((string)departmentSubsystemOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteInvestorRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] investorSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    investorsSubSystem.AddInvestorToStartupCompany(
                        (string)investorSubsystemOperationArguments[0], decimal.Parse((string)investorSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    investorsSubSystem.RemoveInvestor((string)investorSubsystemOperationArguments[0]);
                    break;
            }
        }
    }
}
