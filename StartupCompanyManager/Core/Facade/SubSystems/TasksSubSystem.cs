using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models.Enums;
using Task = StartupCompanyManager.Models.Task;
using TaskStatus = StartupCompanyManager.Models.Enums.TaskStatus;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class TasksSubSystem
    {
        private readonly ITaskRepository _taskRepository;

        public TasksSubSystem(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task AddTaskToProject(
            string name, TaskPriority taskPriority, TaskStatus taskStatus, DateTime assignmentDate,
            DateTime dueDate, string assigneeFullName, string projectName
        )
        {
            Task foundTask = _taskRepository.GetByCondition(t => t.Name == name && t.Assignee.FullName.ToLower() == assigneeFullName);

            bool doesTaskExist = foundTask != null;

            if (doesTaskExist)
            {
                string existingTaskExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_TASK_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingTaskExceptionMessage);
            }

            Task taskToAdd = new()
            {
                Name = name,
                Priority = taskPriority,
                Status = taskStatus
            };

            _taskRepository.Add(taskToAdd, assignmentDate, dueDate, assigneeFullName, projectName);

            return taskToAdd;
        }

        public void ChangeTaskCharacteristic(string name, string assigneeFullName, string characteristic, object value)
        {
            Task taskToUpdate = _taskRepository.GetByCondition(t => t.Name == name && t.Assignee.FullName.ToLower() == assigneeFullName.ToLower());

            if (taskToUpdate == null)
            {
                string nonExistingTaskExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_TASK_EXCEPTION_MESSAGE, name, assigneeFullName
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingTaskExceptionMessage);
            }

            _taskRepository.Update(taskToUpdate, characteristic, value);
        }

        public void RemoveTask(string name, string assigneeFullName)
        {
            Task taskToRemove = _taskRepository.GetByCondition(t => t.Name == name && t.Assignee.FullName.ToLower() == assigneeFullName.ToLower());

            if (taskToRemove == null)
            {
                string nonExistingTaskExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_TASK_EXCEPTION_MESSAGE, name, assigneeFullName
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingTaskExceptionMessage);
            }

            _taskRepository.Remove(taskToRemove);
        }
    }
}
