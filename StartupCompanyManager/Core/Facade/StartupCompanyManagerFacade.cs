using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade.SubSystems;

namespace StartupCompanyManager.Core.Facade
{
    public class StartupCompanyManagerFacade
    {
        private readonly DepartmentsSubSystem _departmentsSubSystem;

        private readonly InvestorsSubSystem _investorsSubSystem;

        private readonly TeamsSubSystem _teamsSubSystem;

        private readonly ProjectsSubSystem _projectsSubSystem;

        private readonly EmployeesSubSystem _employeesSubSystem;

        public StartupCompanyManagerFacade(
            DepartmentsSubSystem departmentSubSystem,
            InvestorsSubSystem investorsSubSystem,
            TeamsSubSystem teamsSubSystem,
            ProjectsSubSystem projectsSubSystem,
            EmployeesSubSystem employeesSubSystem
        )
        {
            _departmentsSubSystem = departmentSubSystem;
            _investorsSubSystem = investorsSubSystem;
            _teamsSubSystem = teamsSubSystem;
            _projectsSubSystem = projectsSubSystem;
            _employeesSubSystem = employeesSubSystem;
        }

        public void ExecuteDepartmentRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] departmentRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _departmentsSubSystem.AddDepartmentToStartupCompany(
                        (string)departmentRelatedOperationArguments[0],
                        int.Parse((string)departmentRelatedOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _departmentsSubSystem.ChangeDepartmentCharacteristic(
                        (string)departmentRelatedOperationArguments[0],
                        (string)departmentRelatedOperationArguments[1],
                        departmentRelatedOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Assign:
                    _employeesSubSystem.AssignEmployeeAsHeadOfDepartment(
                        (string)departmentRelatedOperationArguments[0],
                        (string)departmentRelatedOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _departmentsSubSystem.RemoveDepartment((string)departmentRelatedOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteInvestorRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] investorRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _investorsSubSystem.AddInvestorToStartupCompany(
                        (string)investorRelatedOperationArguments[0],
                        decimal.Parse((string)investorRelatedOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _investorsSubSystem.ChangeInvestorCharacteristic(
                        (string)investorRelatedOperationArguments[0],
                        (string)investorRelatedOperationArguments[1],
                        investorRelatedOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _investorsSubSystem.RemoveInvestor((string)investorRelatedOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteTeamRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] teamRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _teamsSubSystem.AddTeamToDepartment(
                        (string)teamRelatedOperationArguments[0],
                        (string)teamRelatedOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _teamsSubSystem.ChangeTeamCharacteristic(
                        (string)teamRelatedOperationArguments[0],
                        (string)teamRelatedOperationArguments[1],
                        teamRelatedOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Assign:
                    _employeesSubSystem.AssignEmployeeAsTeamLead(
                        (string)teamRelatedOperationArguments[0],
                        (string)teamRelatedOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _teamsSubSystem.RemoveTeam((string)teamRelatedOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteProjectRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] projectRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _projectsSubSystem.AddProjectToTeam(
                        (string)projectRelatedOperationArguments[0],
                        (DateTime)projectRelatedOperationArguments[1],
                        (DateTime)projectRelatedOperationArguments[2],
                        (string)projectRelatedOperationArguments[3]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _projectsSubSystem.ChangeProjectCharacteristic(
                        (string)projectRelatedOperationArguments[0],
                        (string)projectRelatedOperationArguments[1],
                        projectRelatedOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _projectsSubSystem.RemoveProject((string)projectRelatedOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteEmployeeRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] employeeRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _employeesSubSystem.AddEmployeeToStartupCompany(
                        (string)employeeRelatedOperationArguments[0],
                        (string)employeeRelatedOperationArguments[1],
                        (string)employeeRelatedOperationArguments[2],
                        (string)employeeRelatedOperationArguments[3],
                        decimal.Parse((string)employeeRelatedOperationArguments[4]),
                        int.Parse((string)employeeRelatedOperationArguments[5]),
                        (DateTime)employeeRelatedOperationArguments[6],
                        int.Parse((string)employeeRelatedOperationArguments[7])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _employeesSubSystem.ChangeEmployeeCharacteristic(
                        (string)employeeRelatedOperationArguments[0],
                        (string)employeeRelatedOperationArguments[1],
                        employeeRelatedOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _employeesSubSystem.RemoveEmployee((string)employeeRelatedOperationArguments[0]);
                    break;
            }
        }
    }
}
