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
        private DepartmentsSubSystem _departmentsSubSystem;

        private InvestorsSubSystem _investorsSubSystem;

        public StartupCompanyManagerFacade(DepartmentsSubSystem departmentSubSystem, InvestorsSubSystem investorsSubSystem)
        {
            _departmentsSubSystem = departmentSubSystem;
            _investorsSubSystem = investorsSubSystem;
        }

        public void ExecuteDepartmentRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] departmentSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _departmentsSubSystem.AddDepartmentToStartupCompany(
                        (string)departmentSubsystemOperationArguments[0], 
                        int.Parse((string)departmentSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _departmentsSubSystem.RemoveDepartment((string)departmentSubsystemOperationArguments[0]);
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
                    _investorsSubSystem.AddInvestorToStartupCompany(
                        (string)investorSubsystemOperationArguments[0], 
                        decimal.Parse((string)investorSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _investorsSubSystem.RemoveInvestor((string)investorSubsystemOperationArguments[0]);
                    break;
            }
        }
    }
}
