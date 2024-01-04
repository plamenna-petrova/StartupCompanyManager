using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Composite.Composites;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public ICollection<Employee> GetAll()
        {
            return StartupCompany.Employees.ToList();
        }

        public Employee GetByCondition(Func<Employee, bool> entityFilterPredicate)
        {
            return StartupCompany.Employees.FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Employee> GetAllByCondition(Func<Employee, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Employees.Where(entitiesFilterPredicate).ToList();
        }

        public void Add(Employee employee, params object[] entityCreationArguments)
        {
            StartupCompany.Employees.Add(employee);
        }

        public void Update(Employee employee, string propertyName, object propertyValueToSet)
        {
            try
            {
                string formattedEmployeePropertyName = string.Join(string.Empty, propertyName.Split(" "));
                var employeePropertyInfo = employee.GetType().GetProperty(formattedEmployeePropertyName);
                var employeePropertyConversionType = employeePropertyInfo!.PropertyType;

                if (employeePropertyConversionType.IsPrimitive || employeePropertyConversionType == typeof(decimal) ||
                    employeePropertyConversionType == typeof(string)
                )
                {
                    var convertedEmployeePropertyValueToSet = Convert.ChangeType(propertyValueToSet, employeePropertyConversionType);
                    employee.GetType().GetProperty(formattedEmployeePropertyName)!.SetValue(employee, convertedEmployeePropertyValueToSet);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(string.Format(
                        CommandsMessagesConstants.CHANGED_EMPLOYEE_OF_STARTUP_COMPANY_SUCCESS_MESSAGE,
                        employee.FullName,
                        propertyName,
                        convertedEmployeePropertyValueToSet
                    ));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                            CommandsMessagesConstants.CHANGE_EMPLOYEE_CONCRETE_COMMAND_ARGUMENTS_PATTERN
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

        public void Assign(Employee employee, string assignmentOption, string filterTerm)
        {
            switch (assignmentOption)
            {
                case nameof(Department):
                    var departmentToReceiveHeadEmployeeAssignment = StartupCompany.Departments.FirstOrDefault(d => d.Name == filterTerm)!;

                    if (departmentToReceiveHeadEmployeeAssignment != null)
                    {
                        if (departmentToReceiveHeadEmployeeAssignment.HeadOfDepartment == null)
                        {
                            departmentToReceiveHeadEmployeeAssignment.HeadOfDepartment = (HeadOfDepartment)employee;
                        }
                        else
                        {
                            throw new ExistingStartupCompanyManagerEntityException(
                                string.Format(
                                    ExceptionMessagesConstants.EXISTING_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE,
                                    departmentToReceiveHeadEmployeeAssignment.Name,
                                    departmentToReceiveHeadEmployeeAssignment.HeadOfDepartment!.FullName
                                )
                            );
                        }
                    }
                    else
                    {
                        throw new NonExistingStartupCompanyManagerEntityException(
                            string.Format(
                                ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, filterTerm
                            )
                        );
                    }
                    break;
                case nameof(HeadOfDepartment):
                    if (GetByCondition(e => e is HeadOfDepartment && e.FullName == filterTerm) is HeadOfDepartment headOfDepartmentToFind)
                    {
                        var departmentOfHeadEmployee = StartupCompany.Departments
                            .FirstOrDefault(d => d.HeadOfDepartment.FullName == headOfDepartmentToFind.FullName)!;

                        if (departmentOfHeadEmployee.Teams.Contains(employee.Team))
                        {
                            if (!headOfDepartmentToFind.Employees.Contains(employee))
                            {
                                headOfDepartmentToFind.Add(employee);
                            }
                            else
                            {
                                throw new ExistingStartupCompanyManagerEntityException(
                                    string.Format(
                                        ExceptionMessagesConstants.EXISTING_HEAD_OF_DEPARTMENT_TEAM_LEAD_SUBORDINATE_EXCEPTION_MESSAGE,
                                        headOfDepartmentToFind.FullName,
                                        employee.FullName
                                    )
                                );
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                string.Format(
                                    ExceptionMessagesConstants.DEPARTMENT_AND_TEAM_LEAD_TEAMS_MISMATCH_EXCEPTION_MESSAGE,
                                    departmentOfHeadEmployee.Name,
                                    employee.Team
                                )
                            );
                        }
                    }
                    else
                    {
                        string nonExistingHeadOfDepartmentExceptionMessage = string.Format(
                            ExceptionMessagesConstants.NON_EXISTING_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE, filterTerm
                        );

                        throw new NonExistingStartupCompanyManagerEntityException(nonExistingHeadOfDepartmentExceptionMessage);
                    }
                    break;
                case nameof(Team):
                    var teamToReceiveLeadEmployeeAssignment = StartupCompany.Departments
                           .SelectMany(d => d.Teams)
                           .FirstOrDefault(t => t.Name == filterTerm)!;

                    if (teamToReceiveLeadEmployeeAssignment != null)
                    {
                        if (teamToReceiveLeadEmployeeAssignment.TeamLead == null)
                        {
                            ((TeamLead)employee).Team = teamToReceiveLeadEmployeeAssignment!;
                            teamToReceiveLeadEmployeeAssignment.TeamLead = (TeamLead)employee;
                        }
                        else
                        {
                            throw new ExistingStartupCompanyManagerEntityException(
                                string.Format(
                                    ExceptionMessagesConstants.EXISTING_TEAM_LEAD_EXCEPTION_MESSAGE,
                                    teamToReceiveLeadEmployeeAssignment.Name,
                                    teamToReceiveLeadEmployeeAssignment.TeamLead.FullName!
                                )
                            );
                        }
                    }
                    else
                    {
                        throw new NonExistingStartupCompanyManagerEntityException(
                            string.Format(
                                ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, filterTerm
                            )
                        );
                    }
                    break;
                case nameof(TeamLead):
                    if (GetByCondition(e => e is TeamLead && e.FullName == filterTerm) is TeamLead teamLeadToFind)
                    {
                        if (teamLeadToFind.Team != null)
                        {
                            var otherStartupCompanyTeamLeads = GetAllByCondition(e => e is TeamLead && e != teamLeadToFind);

                            var otherStartupCompanyTeamLeadsSubordinateEmployees = otherStartupCompanyTeamLeads
                                .SelectMany(tl => ((TeamLead)tl).Employees)
                                .ToList();

                            var existingTeamLeadOfEmployee = otherStartupCompanyTeamLeads
                                .Where(tl => ((TeamLead)tl).Employees.Contains(employee))
                                .FirstOrDefault()!;

                            if (existingTeamLeadOfEmployee != null)
                            {
                                throw new InvalidOperationException(
                                    string.Format(
                                        ExceptionMessagesConstants.EMPLOYEE_ALREADY_SUBORDINATE_OF_OTHER_TEAM_LEAD_EXCEPTION_MESAGE,
                                        employee.FullName,
                                        existingTeamLeadOfEmployee.FullName
                                    )
                                 );
                            }
                            else
                            {
                                if (!teamLeadToFind.Employees.Contains(employee))
                                {
                                    teamLeadToFind.Add(employee);
                                    employee.Team = teamLeadToFind.Team;
                                }
                                else
                                {
                                    throw new ExistingStartupCompanyManagerEntityException(
                                        string.Format(
                                            ExceptionMessagesConstants.EXISTING_TEAM_LEAD_EMPLOYEE_SUBORDINATE_EXCEPTION_MESSAGE,
                                            teamLeadToFind.FullName,
                                            employee.FullName
                                        )
                                    );
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(ExceptionMessagesConstants.TEAM_LEAD_NOT_ASSIGNED_TEAM_EXCEPTION_MESSAGE);
                        }
                    }
                    else
                    {
                        string nonExistingTeamLeadExceptionMessage = string.Format(
                            ExceptionMessagesConstants.NON_EXISTING_TEAM_LEAD_EXCEPTION_MESSAGE, filterTerm
                        );

                        throw new NonExistingStartupCompanyManagerEntityException(nonExistingTeamLeadExceptionMessage);
                    }
                    break;
            }
        }

        public void Remove(Employee employee, params object[] entityRemovalArguments)
        {
            if (employee is HeadOfDepartment)
            {
                var departmentOfHeadEmployee = StartupCompany.Departments.FirstOrDefault(d => d.HeadOfDepartment == employee);

                if (departmentOfHeadEmployee != null)
                {
                    departmentOfHeadEmployee.HeadOfDepartment = null!;
                }
            }
            else if (employee is TeamLead)
            {
                var teamOfLeadEmployee = StartupCompany.Departments.SelectMany(d => d.Teams).FirstOrDefault(t => t.TeamLead == employee);

                var headOfDepartmentSuperiorOfTeamLead = StartupCompany.Departments
                    .Select(d => d.HeadOfDepartment)
                    .FirstOrDefault(hod => hod.Employees.Contains(employee));

                if (teamOfLeadEmployee != null)
                {
                    teamOfLeadEmployee.TeamLead = null!;
                } 

                headOfDepartmentSuperiorOfTeamLead?.Employees.Remove(employee);
            }
            else
            {
                var teamLeadSuperiorOfEmployee = StartupCompany.Departments
                    .SelectMany(d => d.Teams).Select(t => t.TeamLead)
                    .FirstOrDefault(tl => tl.Employees.Contains(employee));

                teamLeadSuperiorOfEmployee?.Employees.Remove(employee);
            }

            StartupCompany.Employees.Remove(employee);
        }

        public bool Exists(Employee employeeToFind, params object[] entityExistenceArguments)
        {
            return StartupCompany.Employees.Contains(employeeToFind);
        }
    }
}