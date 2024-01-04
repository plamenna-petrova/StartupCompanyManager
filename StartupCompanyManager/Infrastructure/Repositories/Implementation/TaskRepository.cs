using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Extensions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models.Enums;
using Task = StartupCompanyManager.Models.Task;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

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
                .Where(d => d.Teams.Any())
                .SelectMany(d => d.Teams)
                .Select(t => t.Project)
                .FirstOrDefault(p => p.Name == projectName) 
                    ?? throw new NonExistingStartupCompanyManagerEntityException(
                        string.Format(
                            ExceptionMessagesConstants.NON_EXISTING_PROJECT_EXCEPTION_MESSAGE, projectName
                        )
                    );

            if (targetProjectOfTask.Team.TeamLead == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessagesConstants.NOT_ASSIGNED_PROJECT_TEAM_LEAD_EMPLOYEE,
                        targetProjectOfTask.Name,
                        targetProjectOfTask.Team.Name
                    )
                );
            }

            var targetTaskAssignee = StartupCompany.Employees
                .FirstOrDefault(e => e.FullName.ToLower() == ((string)entityCreationArguments[2]).ToLower())! 
                    ?? throw new NonExistingStartupCompanyManagerEntityException(
                        string.Format(
                            ExceptionMessagesConstants.NON_EXISTING_EMPLOYEE_EXCEPTION_MESSAGE, 
                            (string)entityCreationArguments[2]
                        )
                    );

            if (!targetProjectOfTask.Team.TeamLead.Employees.Contains(targetTaskAssignee))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessagesConstants.CANNOT_ASSIGN_TASK_TO_EMPLOYEE_SUBORDINATION_NOT_MET,
                        targetTaskAssignee.FullName,
                        targetProjectOfTask.Team.TeamLead.FullName
                    )
                );
            }

            task.Project = targetProjectOfTask;
            task.AssignmentDate = (DateTime)entityCreationArguments[0];
            task.DueDate = (DateTime)entityCreationArguments[1];
            task.Assignee = targetTaskAssignee;
            targetProjectOfTask.Tasks.Add(task);
        }

        public void Update(Task task, string propertyName, object propertyValueToSet)
        {
            try
            {
                string updateTaskArgumentExceptionMessage = string.Format(
                    ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                    CommandsMessagesConstants.CHANGE_PROJECT_TASK_CONCRETE_COMMAND_ARGUMENTS_PATTERN
                );

                string formattedTaskPropertyName = string.Join(string.Empty, propertyName.Split(" "));

                var taskPropertyInfo = task.GetType().GetProperty(formattedTaskPropertyName)
                    ?? throw new ArgumentException(updateTaskArgumentExceptionMessage);

                var taskPropertyConversionType = taskPropertyInfo!.PropertyType;

                if (taskPropertyConversionType.BaseType == typeof(Enum))
                {
                    if (taskPropertyConversionType == typeof(TaskPriority))
                    {
                        if (propertyValueToSet.ToString()!.TryParseEnum(caseSensitive: false, out TaskPriority taskPriorityToSet))
                        {
                            task.Priority = taskPriorityToSet;
                        }
                        else
                        {
                            throw new ArgumentException(updateTaskArgumentExceptionMessage);
                        }
                    }

                    if (taskPropertyConversionType == typeof(TaskStatus))
                    {
                        if (propertyValueToSet.ToString()!.TryParseEnum(caseSensitive: false, out TaskStatus taskStatusToSet))
                        {
                            task.Status = taskStatusToSet;
                        }
                        else
                        {
                            throw new ArgumentException(updateTaskArgumentExceptionMessage);
                        }
                    }
                }
                else
                {
                    if (propertyValueToSet.TryChangeType(taskPropertyConversionType))
                    {
                        var convertedTaskPropertyValueToSet = Convert.ChangeType(propertyValueToSet, taskPropertyConversionType);
                        task.GetType().GetProperty(formattedTaskPropertyName)!.SetValue(task, convertedTaskPropertyValueToSet);

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine(string.Format(
                            CommandsMessagesConstants.CHANGED_PROJECT_TASK_OF_EMPLOYEE_SUCCESS_MESSAGE,
                            task.Name,
                            task.Assignee.FullName,
                            propertyName,
                            convertedTaskPropertyValueToSet
                        ));
                    }
                    else
                    {
                        throw new ArgumentException(updateTaskArgumentExceptionMessage);
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is ArgumentException argumentException) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(argumentException.Message);
                }

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
                .Where(d => d.Teams.Any())
                .SelectMany(d => d.Teams)
                .Select(t => t.Project)
                .FirstOrDefault(p => p.Tasks.Contains(task));

            projectOfTask?.Tasks.Remove(task);
        }

        public bool Exists(Task taskToFind, params object[] entityExistenceArguments)
        {
            string projectName = (string)entityExistenceArguments[0];

            var projectOfTask = StartupCompany.Departments
                .Where(d => d.Teams.Any())
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
