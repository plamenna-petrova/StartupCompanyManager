using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Singleton;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public ICollection<Employee> GetAll()
        {
            return StartupCompany.Employees.ToList();
        }

        public Employee GetByCondition(Func<Employee, bool> entityFilterDelegate)
        {
            return StartupCompany.Employees.FirstOrDefault(entityFilterDelegate)!;
        }

        public ICollection<Employee> GetAllByCondition(Func<Employee, bool> entitiesFilterDelegate)
        {
            return StartupCompany.Employees.Where(entitiesFilterDelegate).ToList();
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
