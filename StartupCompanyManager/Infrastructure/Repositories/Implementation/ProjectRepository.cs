using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ICollection<Project> GetAll()
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .ToList();
        }

        public Project GetByCondition(Func<Project, bool> entityFilterDelegate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .FirstOrDefault(entityFilterDelegate)!;
        }

        public ICollection<Project> GetAllByCondition(Func<Project, bool> entitiesFilterDelegate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .Where(entitiesFilterDelegate)
                .ToList();
        }

        public void Add(Project project, params object[] entityCreationArguments)
        {
            string teamName = (string)entityCreationArguments[0];
            var targetTeamOfProject = StartupCompany.Departments.SelectMany(d => d.Teams).FirstOrDefault(t => t.Name == teamName);

            if (targetTeamOfProject == null)
            {
                throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(
                        ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, teamName
                    )
                );
            }
            else
            {
                project.Team = targetTeamOfProject;
                targetTeamOfProject.Project = project;
            }
        }

        public void Update(Project project, string propertyName, object propertyValueToSet)
        {
            Type propertyValueToSetType = propertyValueToSet.GetType();

            if (propertyValueToSetType.IsPrimitive || propertyValueToSetType == typeof(decimal) || 
                propertyValueToSetType == typeof(string)
            )
            {
                project.GetType().GetProperty(propertyName)!.SetValue(project, propertyValueToSet);
            }
            else
            {
                throw new ArgumentException(
                  string.Format(
                      ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                      CommandsMessagesConstants.CHANGE_PROJECT_CONCRETE_COMMAND_ARGUMENTS_PATTERN
                  )
                );
            }
        }

        public void Remove(Project project, params object[] entityRemovalArguments)
        {
            project.Team.Project = null!;
        }

        public bool Exists(Project projectToFind, params object[] entityExistenceArguments)
        {
            string teamName = (string)entityExistenceArguments[0];

            var teamOfProject = StartupCompany.Departments.SelectMany(d => d.Teams).FirstOrDefault(t => t.Name == teamName);

            return teamOfProject == null
                ? throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, teamName)
                  )
                : teamOfProject.Project.Name == projectToFind.Name;
        }
    }
}
