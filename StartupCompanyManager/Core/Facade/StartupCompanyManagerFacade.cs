using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade.SubSystems;

namespace StartupCompanyManager.Core.Facade
{
    public class StartupCompanyManagerFacade
    {
        private DepartmentsSubSystem _departmentsSubSystem;

        private InvestorsSubSystem _investorsSubSystem;

        public StartupCompanyManagerFacade(
            DepartmentsSubSystem departmentSubSystem, 
            InvestorsSubSystem investorsSubSystem
        )
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
                    _departmentsSubSystem.ChangeDepartmentCharacteristic(
                        (string)departmentSubsystemOperationArguments[0],
                        (string)departmentSubsystemOperationArguments[1],
                        departmentSubsystemOperationArguments[2]
                    );
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
                    _investorsSubSystem.ChangeInvestorCharacteristic(
                        (string)investorSubsystemOperationArguments[0],
                        (string)investorSubsystemOperationArguments[1],
                        investorSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _investorsSubSystem.RemoveInvestor((string)investorSubsystemOperationArguments[0]);
                    break;
            }
        }
    }
}
