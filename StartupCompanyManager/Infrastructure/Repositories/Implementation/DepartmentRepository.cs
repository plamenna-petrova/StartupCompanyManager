﻿using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public ICollection<Department> GetAll()
        {
            return StartupCompany.Departments.ToList();
        }

        public Department GetByCondition(Func<Department, bool> filterExpression)
        {
            return StartupCompany.Departments.FirstOrDefault(filterExpression)!;
        }

        public ICollection<Department> GetAllByCondition(Func<Department, bool> filterExpression)
        {
            return StartupCompany.Departments.Where(filterExpression).ToList();
        }

        public void Add(Department department)
        {
            StartupCompany.Departments.Add(department);
        }

        public void Update(Department department, string propertyName, object propertyValueToSet)
        {
            if(!propertyValueToSet.GetType().IsPrimitive)
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE, 
                        CommandsMessagesConstants.CHANGE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN
                    )
                );
            }
            else
            {
                department.GetType().GetProperty(propertyName)!.SetValue(department, propertyValueToSet);
            }
        }

        public void Remove(Department department)
        {
            StartupCompany.Departments.Remove(department);
        }

        public bool Exists(Department departmentToFind)
        {
            return StartupCompany.Departments.Contains(departmentToFind);
        }
    }
}
