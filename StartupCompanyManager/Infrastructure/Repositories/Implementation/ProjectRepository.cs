using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models.Singleton;
using StartupCompanyManager.Models;

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

        public Project GetByCondition(Func<Project, bool> entityFilterPredicate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Project> GetAllByCondition(Func<Project, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .Where(t => t.Project is not null)
                .Select(t => t.Project)
                .Where(entitiesFilterPredicate)
                .ToList();
        }

        public void Add(Project project, params object[] entityCreationArguments)
        {
            string teamName = (string)entityCreationArguments[0];

            var targetTeamOfProject = StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .FirstOrDefault(t => t.Name == teamName) ?? throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(
                        ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, teamName
                    )
                );

            project.Team = targetTeamOfProject;
            targetTeamOfProject.Project = project;
        }

        public void Update(Project project, string propertyName, object propertyValueToSet)
        {
            try
            {
                string formattedProjectPropertyName = string.Join(string.Empty, propertyName.Split(" "));
                var projectPropertyInfo = project.GetType().GetProperty(formattedProjectPropertyName);
                var projectPropertyConversionType = projectPropertyInfo!.PropertyType;

                if (projectPropertyConversionType.IsPrimitive || projectPropertyConversionType == typeof(decimal) ||
                    projectPropertyConversionType == typeof(string)
                )
                {
                    var convertedProjectPropertyValueToSet = Convert.ChangeType(propertyValueToSet, projectPropertyConversionType);
                    project.GetType().GetProperty(formattedProjectPropertyName)!.SetValue(project, convertedProjectPropertyValueToSet);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(string.Format(
                        CommandsMessagesConstants.CHANGED_PROJECT_OF_STARTUP_COMPANY_SUCCESS_MESSAGE,
                        project.Name,
                        propertyName,
                        convertedProjectPropertyValueToSet
                    ));
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
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.InnerException.Message);
                }
            }
        }

        public void Remove(Project project, params object[] entityRemovalArguments)
        {
            var teamOfProject = StartupCompany.Departments
                .SelectMany(d => d.Teams)
                .FirstOrDefault(t => t.Project.Name == project.Name);   

            if (teamOfProject != null)
            {
                teamOfProject.Project = null!;
            }
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
