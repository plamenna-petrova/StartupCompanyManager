using StartupCompanyManager.Constants;
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

        public Department GetByCondition(Func<Department, bool> entityFilterDelegate)
        {
            return StartupCompany.Departments.FirstOrDefault(entityFilterDelegate)!;
        }

        public ICollection<Department> GetAllByCondition(Func<Department, bool> entitiesFilterDelegate)
        {
            return StartupCompany.Departments.Where(entitiesFilterDelegate).ToList();
        }

        public void Add(Department department, params object[] entityCreationArguments)
        {
            StartupCompany.Departments.Add(department);
        }

        public void Update(Department department, string propertyName, object propertyValueToSet)
        {
            try
            {
                string formattedDepartmentPropertyName = string.Join(string.Empty, propertyName.Split(" "));
                var departmentPropertyInfo = department.GetType().GetProperty(formattedDepartmentPropertyName);
                var departmentPropertyConversionType = departmentPropertyInfo!.PropertyType;

                if (departmentPropertyConversionType.IsPrimitive || departmentPropertyConversionType == typeof(decimal) ||
                    departmentPropertyConversionType == typeof(string)
                )
                {
                    var convertedDepartmentPropertyValueToSet = Convert.ChangeType(propertyValueToSet, departmentPropertyConversionType);
                    department.GetType().GetProperty(formattedDepartmentPropertyName)!.SetValue(department, convertedDepartmentPropertyValueToSet);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                            CommandsMessagesConstants.CHANGE_DEPARTMENT_CONCRETE_COMMAND_ARGUMENTS_PATTERN
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
