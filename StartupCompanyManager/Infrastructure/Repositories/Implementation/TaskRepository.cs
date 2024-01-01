using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using Task = StartupCompanyManager.Models.Task;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public ICollection<Task> GetAll()
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .SelectMany(p => p.Tasks)
                .ToList();
        }

        public Task GetByCondition(Func<Task, bool> entityFilterPredicate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .SelectMany(p => p.Tasks)
                .FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Task> GetAllByCondition(Func<Task, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .SelectMany(p => p.Tasks)
                .Where(entitiesFilterPredicate)
                .ToList();
        }

        public void Add(Task task, params object[] entityCreationArguments)
        {
            string projectName = (string)entityCreationArguments[3];

            var targetProjectOfTask = StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Select(t => t.Project)
                .FirstOrDefault(p => p.Name == projectName);

            if (targetProjectOfTask == null)
            {
                throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(
                        ExceptionMessagesConstants.NON_EXISTING_PROJECT_EXCEPTION_MESSAGE, projectName
                    )
                );
            }
            else
            {
                task.Project = targetProjectOfTask;
                task.AssignmentDate = (DateTime)entityCreationArguments[0];
                task.DueDate = (DateTime)entityCreationArguments[1];
                task.Assignee = StartupCompany.Employees.FirstOrDefault(e => e.FullName.ToLower() == (string)entityCreationArguments[2])!;
                targetProjectOfTask.Tasks.Add(task);
            }
        }

        public void Update(Task task, string propertyName, object propertyValueToSet)
        {
            try
            {
                string formattedTaskPropertyName = string.Join(string.Empty, propertyName.Split(" "));
                var taskPropertyInfo = task.GetType().GetProperty(formattedTaskPropertyName);
                var taskPropertyConversionType = taskPropertyInfo!.PropertyType;

                if (taskPropertyConversionType.IsPrimitive || taskPropertyConversionType == typeof(decimal) ||
                    taskPropertyConversionType == typeof(string)
                )
                {
                    var convertedTaskPropertyValueToSet = Convert.ChangeType(propertyValueToSet, taskPropertyConversionType);
                    task.GetType().GetProperty(formattedTaskPropertyName)!.SetValue(task, convertedTaskPropertyValueToSet);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                            CommandsMessagesConstants.CHANGE_PROJECT_TASK_CONCRETE_COMMAND_ARGUMENTS_PATTERN
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

        public void Remove(Task task, params object[] entityRemovalArguments)
        {
            var projectOfTask = StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Select(t => t.Project)
                .FirstOrDefault(p => p.Tasks.Contains(task));

            projectOfTask?.Tasks.Remove(task);
        }

        public bool Exists(Task taskToFind, params object[] entityExistenceArguments)
        {
            string projectName = (string)entityExistenceArguments[0];

            var projectOfTask = StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Select(t => t.Project)
                .FirstOrDefault(p => p.Name == projectName);

            return projectOfTask == null
                ? throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(ExceptionMessagesConstants.NON_EXISTING_PROJECT_EXCEPTION_MESSAGE, projectName)
                  )
                : projectOfTask.Tasks.Contains(taskToFind);
        }
    }
}
