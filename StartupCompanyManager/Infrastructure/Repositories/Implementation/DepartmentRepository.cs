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

        public Department GetByCondition(Func<Department, bool> entityFilterPredicate)
        {
            return StartupCompany.Departments.FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Department> GetAllByCondition(Func<Department, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Departments.Where(entitiesFilterPredicate).ToList();
        }

        public void Add(Department department, params object[] entityCreationArguments)
        {
            StartupCompany.Departments.Add(department);
        }

        public void Update(Department department, string propertyName, object propertyValueToSet)
        {
            try
            {
                string updateDepartmentArgumentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                    CommandsMessagesConstants.CHANGE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN
                );

                string formattedDepartmentPropertyName = string.Join(string.Empty, propertyName.Split(" "));

                var departmentPropertyInfo = department.GetType().GetProperty(formattedDepartmentPropertyName) 
                    ?? throw new ArgumentException(updateDepartmentArgumentExceptionMessage);

                var departmentPropertyConversionType = departmentPropertyInfo!.PropertyType;

                if (departmentPropertyConversionType.IsPrimitive || departmentPropertyConversionType == typeof(decimal) ||
                    departmentPropertyConversionType == typeof(string)
                )
                {
                    var convertedDepartmentPropertyValueToSet = Convert.ChangeType(propertyValueToSet, departmentPropertyConversionType);
                    department.GetType().GetProperty(formattedDepartmentPropertyName)!.SetValue(department, convertedDepartmentPropertyValueToSet);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(string.Format(
                        CommandsMessagesConstants.CHANGED_DEPARTMENT_OF_STARTUP_COMPANY_SUCCESS_MESSAGE,
                        department.Name,
                        propertyName,
                        convertedDepartmentPropertyValueToSet
                    ));
                }
                else
                {
                    throw new ArgumentException(updateDepartmentArgumentExceptionMessage);
                }
            }
            catch (Exception exception)
            {
                if (exception is ArgumentException argumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(argumentException.Message);
                }
                else
                {
                    if (exception.InnerException != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.InnerException.Message);
                    }
                }
            }
        }

        public void Remove(Department department, params object[] entityRemovalArguments)
        {
            StartupCompany.Departments.Remove(department);
        }

        public bool Exists(Department departmentToFind, params object[] entityExistenceArguments)
        {
            return StartupCompany.Departments.Contains(departmentToFind);
        }
    }
}
