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
            Type propertyValueToSetType = propertyValueToSet.GetType();

            if (propertyValueToSet.GetType().IsPrimitive || propertyValueToSetType == typeof(decimal) || 
                propertyValueToSetType == typeof(string)
            )
            {
                department.GetType().GetProperty(propertyName)!.SetValue(department, propertyValueToSet);
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
