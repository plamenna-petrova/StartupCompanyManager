using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class ProjectsSubSystem
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsSubSystem(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project AddProjectToTeam(string name, DateTime assignmentDate, DateTime deadline, string team)
        {
            Project foundProject = _projectRepository.GetByCondition(p => p.Name == name);

            bool doesProjectExist = foundProject != null;

            if (doesProjectExist)
            {
                string existingProjectExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_PROJECT_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingProjectExceptionMessage);
            }

            Project projectToAdd = new(name, assignmentDate, deadline);

            _projectRepository.Add(projectToAdd, team);

            return projectToAdd;
        }

        public void ChangeProjectCharacteristic(string name, string characteristic, object value)
        {
            Project projectToUpdate = _projectRepository.GetByCondition(p => p.Name == name);

            if (projectToUpdate == null)
            {
                string nonExistingProjectExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_PROJECT_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingProjectExceptionMessage);
            }

            _projectRepository.Update(projectToUpdate, characteristic, value);
        }

        public void RemoveProject(string name)
        {
            Project projectToRemove = _projectRepository.GetByCondition(p => p.Name == name);

            if (projectToRemove == null)
            {
                string nonExistingProjectExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_PROJECT_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingProjectExceptionMessage);
            }

            _projectRepository.Remove(projectToRemove);
        }
    }
}
