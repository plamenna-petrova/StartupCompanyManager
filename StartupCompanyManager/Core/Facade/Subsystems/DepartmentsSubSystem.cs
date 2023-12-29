using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class DepartmentsSubSystem
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsSubSystem(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department AddDepartmentToStartupCompany(string name, int yearOfEstablishment)
        {
            Department foundDepartment = _departmentRepository.GetAllByCondition(d => d.Name == name).FirstOrDefault()!;

            bool doesDepartmentExist = foundDepartment != null;

            if (doesDepartmentExist)
            {
                string existingDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingDepartmentExceptionMessage);
            }

            Department departmentToAdd = new(name, yearOfEstablishment);

            _departmentRepository.Add(departmentToAdd);

            return departmentToAdd;
        }

        public void RemoveDepartment(string name)
        {
            Department departmentToRemove = _departmentRepository.GetAllByCondition(d => d.Name == name).FirstOrDefault()!;

            if (departmentToRemove == null) 
            {
                string nonExistingDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingDepartmentExceptionMessage);
            }

            _departmentRepository.Remove(departmentToRemove);
        }
    }
}