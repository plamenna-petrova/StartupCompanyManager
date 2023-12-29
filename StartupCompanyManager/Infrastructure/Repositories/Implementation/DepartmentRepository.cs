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
            department.GetType().GetProperty(propertyName)!.SetValue(department, propertyValueToSet);
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
