using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class DepartmentsSubSystem
    {
        private IStartupCompany startupCompany;

        public DepartmentsSubSystem(IStartupCompany startupCompany)
        {
            this.startupCompany = startupCompany;
        }

        public Department AddDepartmentToStartupCompany(string name, int yearOfEstablishment)
        {
            Department foundDepartment = FindDepartment(name);

            bool doesDepartmentExist = foundDepartment != null;

            if (doesDepartmentExist)
            {
                string existingDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingDepartmentExceptionMessage);
            }

            Department departmentToAdd = new Department(name, yearOfEstablishment);

            startupCompany.Departments.Add(departmentToAdd);

            return departmentToAdd;
        }

        public void RemoveDepartment(string name)
        {
            Department departmentToRemove = FindDepartment(name);

            if (departmentToRemove == null) 
            {
                string nonExistingDepartmentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingDepartmentExceptionMessage);
            }

            startupCompany.Departments.Remove(departmentToRemove);
        }

        private Department FindDepartment(string name) => startupCompany.Departments.FirstOrDefault(d => d.Name == name);
    }
}