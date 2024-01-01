using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Extensions;
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

        public void Assign(Employee employee, string assignmentOption, string filter)
        {
            switch (assignmentOption)
            {
                case nameof(Department):
                    var departmentToReceiveHeadEmployeeAssignment = StartupCompany.Departments.FirstOrDefault(d => d.Name == filter)!;

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
                                ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, filter
                            )
                        );
                    }
                    break;
                case nameof(TeamLead):
                    var teamToReceiveLeadEmployeeAssignment = StartupCompany.Departments
                        .SelectMany(d => d.Teams)
                        .FirstOrDefault(t => t.Name == filter)!;
                    
                    if (teamToReceiveLeadEmployeeAssignment != null)
                    {
                        if (teamToReceiveLeadEmployeeAssignment.TeamLead == null)
                        {
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
                                ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, filter
                            )
                        );
                    }
                    break;
            }
        }

        public void Remove(Employee employee, params object[] entityRemovalArguments)
        {
            StartupCompany.Employees.Remove(employee);
        }

        public bool Exists(Employee employeeToFind, params object[] entityExistenceArguments)
        {
            return StartupCompany.Employees.Contains(employeeToFind);
        }
    }
}
