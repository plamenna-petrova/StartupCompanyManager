using StartupCompanyManager.Constants;
using StartupCompanyManager.Core.Command.Abstraction;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Composite.Composites;
using System.Reflection;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class EmployeesSubSystem
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesSubSystem(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployeeToStartupCompany(
            string employeeType, string firstName, string lastName, string position,
            decimal monthlySalary, int yearOfWorkExperience, DateTime birthDate, int rating
        )
        {
            Employee foundEmployee = _employeeRepository.GetByCondition(
                e => e.FirstName == firstName && e.LastName == lastName && e.BirthDate == birthDate
            );

            bool doesEmployeeExist = foundEmployee != null;

            if (doesEmployeeExist)
            {
                string existingDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_EMPLOYEE_EXCEPTION_MESSAGE, firstName, lastName, birthDate.ToString("dd.MM.yyy")
                );

                throw new ExistingStartupCompanyManagerEntityException(existingDepartmentExceptionMessage);
            }

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            var foundEmployeeType = executingAssembly.GetTypes()
                .Where(t => typeof(Employee).IsAssignableFrom(t) && !t.IsAbstract)
                .FirstOrDefault(t => t.Name.ToLower() == string.Join(string.Empty, employeeType.ToLower().Split(" ")))
                    ?? throw new ArgumentException(
                          string.Format(ExceptionMessagesConstants.INVALID_EMPLOYEE_TYPE_EXCEPTION_MESSAGE, employeeType)
                       );

            Employee employeeToAdd = (Employee)Activator.CreateInstance(
               foundEmployeeType, 
               new object[] { firstName, lastName, position, monthlySalary, yearOfWorkExperience, birthDate, rating }
            )!;

            _employeeRepository.Add(employeeToAdd);

            return employeeToAdd;
        }

        public void ChangeEmployeeCharacteristic(string fullName, string characteristic, object value)
        {
            Employee employeeToUpdate = _employeeRepository.GetByCondition(e => e.FullName == fullName);

            if (employeeToUpdate == null)
            {
                string nonExistingEmployeeExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_EMPLOYEE_EXCEPTION_MESSAGE, fullName
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingEmployeeExceptionMessage);
            }

            _employeeRepository.Update(employeeToUpdate, characteristic, value);
        }

        public void AssignEmployeeAsHeadOfDepartment(string fullName, string departmentName)
        {
            Employee employeeToAssignAsHeadOfDepartment = _employeeRepository
                .GetByCondition(e => e is HeadOfDepartment && e.FullName == fullName);

            if (employeeToAssignAsHeadOfDepartment == null)
            {
                string nonExistingHeadOfDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_HEAD_OF_DEPARTMENT_EXCEPTION_MESSAGE, fullName
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingHeadOfDepartmentExceptionMessage);
            }

            _employeeRepository.Assign(employeeToAssignAsHeadOfDepartment, nameof(Department), departmentName);
        }

        public void AssignEmployeeAsTeamLead(string fullName, string teamName)
        {
            Employee employeeToAssignAsTeamLead = _employeeRepository
                .GetByCondition(e => e is TeamLead && e.FullName == fullName);

            if (employeeToAssignAsTeamLead == null)
            {
                string nonExistingTeamLeadExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_TEAM_LEAD_EXCEPTION_MESSAGE, fullName
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingTeamLeadExceptionMessage);
            }

            _employeeRepository.Assign(employeeToAssignAsTeamLead, nameof(TeamLead), teamName);
        }

        public void RemoveEmployee(string name)
        {
            Employee employeeToRemove = _employeeRepository.GetByCondition(e => e.FullName == name);

            if (employeeToRemove == null)
            {
                string nonExistingEmployeeExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_EMPLOYEE_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingEmployeeExceptionMessage);
            }

            _employeeRepository.Remove(employeeToRemove);
        }
    }
}
