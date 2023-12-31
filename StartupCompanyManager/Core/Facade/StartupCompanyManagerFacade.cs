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
            params object[] departmentsSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _departmentsSubSystem.AddDepartmentToStartupCompany(
                        (string)departmentsSubsystemOperationArguments[0],
                        int.Parse((string)departmentsSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _departmentsSubSystem.ChangeDepartmentCharacteristic(
                        (string)departmentsSubsystemOperationArguments[0],
                        (string)departmentsSubsystemOperationArguments[1],
                        departmentsSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _departmentsSubSystem.RemoveDepartment((string)departmentsSubsystemOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteInvestorRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] investorsSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _investorsSubSystem.AddInvestorToStartupCompany(
                        (string)investorsSubsystemOperationArguments[0],
                        decimal.Parse((string)investorsSubsystemOperationArguments[1])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _investorsSubSystem.ChangeInvestorCharacteristic(
                        (string)investorsSubsystemOperationArguments[0],
                        (string)investorsSubsystemOperationArguments[1],
                        investorsSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _investorsSubSystem.RemoveInvestor((string)investorsSubsystemOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteTeamRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] teamsSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _teamsSubSystem.AddTeamToDepartment(
                        (string)teamsSubsystemOperationArguments[0],
                        (string)teamsSubsystemOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _teamsSubSystem.ChangeTeamCharacteristic(
                        (string)teamsSubsystemOperationArguments[0],
                        (string)teamsSubsystemOperationArguments[1],
                        teamsSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _teamsSubSystem.RemoveTeam((string)teamsSubsystemOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteProjectRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] projectsSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _projectsSubSystem.AddProjectToTeam(
                        (string)projectsSubsystemOperationArguments[0],
                        (DateTime)projectsSubsystemOperationArguments[1],
                        (DateTime)projectsSubsystemOperationArguments[2],
                        (string)projectsSubsystemOperationArguments[3]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _projectsSubSystem.ChangeProjectCharacteristic(
                        (string)projectsSubsystemOperationArguments[0],
                        (string)projectsSubsystemOperationArguments[1],
                        projectsSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _projectsSubSystem.RemoveProject((string)projectsSubsystemOperationArguments[0]);
                    break;
            }
        }

        public void ExecuteEmployeeRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] employeesSubsystemOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _employeesSubSystem.AddEmployeeToStartupCompany(
                        (string)employeesSubsystemOperationArguments[0],
                        (string)employeesSubsystemOperationArguments[1],
                        (string)employeesSubsystemOperationArguments[2],
                        (string)employeesSubsystemOperationArguments[3],
                        decimal.Parse((string)employeesSubsystemOperationArguments[4]),
                        int.Parse((string)employeesSubsystemOperationArguments[5]),
                        (DateTime)employeesSubsystemOperationArguments[6],
                        int.Parse((string)employeesSubsystemOperationArguments[7])
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _employeesSubSystem.ChangeEmployeeCharacteristic(
                        (string)employeesSubsystemOperationArguments[0],
                        (string)employeesSubsystemOperationArguments[1],
                        employeesSubsystemOperationArguments[2]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _employeesSubSystem.RemoveEmployee((string)employeesSubsystemOperationArguments[0]);
                    break;
            }
        }
    }
}
