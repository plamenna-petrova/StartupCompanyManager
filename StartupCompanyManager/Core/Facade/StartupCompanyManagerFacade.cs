using StartupCompanyManager.Core.Command.Enums;
using StartupCompanyManager.Core.Facade.SubSystems;
using StartupCompanyManager.Models.Enums;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

namespace StartupCompanyManager.Core.Facade
{
    public class StartupCompanyManagerFacade
    {
        private readonly DepartmentsSubSystem _departmentsSubSystem;

        private readonly InvestorsSubSystem _investorsSubSystem;

        private readonly TeamsSubSystem _teamsSubSystem;

        private readonly ProjectsSubSystem _projectsSubSystem;

        private readonly EmployeesSubSystem _employeesSubSystem;

        private readonly TasksSubSystem _tasksSubSystem;    

        public StartupCompanyManagerFacade(
            DepartmentsSubSystem departmentSubSystem,
            InvestorsSubSystem investorsSubSystem,
            TeamsSubSystem teamsSubSystem,
            ProjectsSubSystem projectsSubSystem,
            EmployeesSubSystem employeesSubSystem,
            TasksSubSystem tasksSubSystem
        )
        {
            _departmentsSubSystem = departmentSubSystem;
            _investorsSubSystem = investorsSubSystem;
            _teamsSubSystem = teamsSubSystem;
            _projectsSubSystem = projectsSubSystem;
            _employeesSubSystem = employeesSubSystem;
            _tasksSubSystem = tasksSubSystem;   
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
                case StartupCompanyManagerCommandAction.AssignSuperior:
                    _employeesSubSystem.AssignEmployeeAsHeadOfDepartment(
                        (string)departmentRelatedOperationArguments[0],
                        (string)departmentRelatedOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.AssignSubordinate:
                    _employeesSubSystem.AssignTeamLeadAsHeadOfDepartmentSubordinate(
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
                case StartupCompanyManagerCommandAction.AssignSuperior:
                    _employeesSubSystem.AssignEmployeeAsTeamLead(
                        (string)teamRelatedOperationArguments[0],
                        (string)teamRelatedOperationArguments[1]
                    );
                    break;
                case StartupCompanyManagerCommandAction.AssignSubordinate:
                    _employeesSubSystem.AssignEmployeeAsTeamLeadSubordinate(
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

        public void ExecuteTaskRelatedOperation(
            StartupCompanyManagerCommandAction startupCompanyManagerCommandAction,
            params object[] taskRelatedOperationArguments
        )
        {
            switch (startupCompanyManagerCommandAction)
            {
                case StartupCompanyManagerCommandAction.Add:
                    _tasksSubSystem.AddTaskToProject(
                        (string)taskRelatedOperationArguments[0],
                        (TaskPriority)taskRelatedOperationArguments[1],
                        (TaskStatus)taskRelatedOperationArguments[2],
                        (DateTime)taskRelatedOperationArguments[3],
                        (DateTime)taskRelatedOperationArguments[4],
                        (string)taskRelatedOperationArguments[5],
                        (string)taskRelatedOperationArguments[6]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Change:
                    _tasksSubSystem.ChangeTaskCharacteristic(
                        (string)taskRelatedOperationArguments[0],
                        (string)taskRelatedOperationArguments[1],
                        (string)taskRelatedOperationArguments[2],
                        taskRelatedOperationArguments[3]
                    );
                    break;
                case StartupCompanyManagerCommandAction.Remove:
                    _tasksSubSystem.RemoveTask(
                        (string)taskRelatedOperationArguments[0], 
                        (string)taskRelatedOperationArguments[1]
                    );
                    break;
            }
        }
    }
}
