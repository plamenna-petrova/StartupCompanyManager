using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;

namespace StartupCompanyManager.Infrastructure.Repositories.Implementation
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public ICollection<Team> GetAll()
        {
            return StartupCompany.Departments.SelectMany(d => d.Teams).ToList();
        }

        public Team GetByCondition(Func<Team, bool> entityFilterPredicate)
        {
            return StartupCompany.Departments.SelectMany(d => d.Teams).FirstOrDefault(entityFilterPredicate)!;
        }

        public ICollection<Team> GetAllByCondition(Func<Team, bool> entitiesFilterPredicate)
        {
            return StartupCompany.Departments.SelectMany(d => d.Teams).Where(entitiesFilterPredicate).ToList();
        }

        public void Add(Team team, params object[] entityCreationArguments)
        {
            string departmentName = (string)entityCreationArguments[0];
            var targetDepartmentOfTeam = StartupCompany.Departments.FirstOrDefault(d => d.Name == departmentName);

            if (targetDepartmentOfTeam == null)
            {
                throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(
                        ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, departmentName
                    )
                );
            }
            else
            {
                if (targetDepartmentOfTeam.Teams.FirstOrDefault(t => t.Name == team.Name) != null)
                {
                    throw new ExistingStartupCompanyManagerEntityException(
                        string.Format(
                            ExceptionMessagesConstants.EXISTING_TEAM_EXCEPTION_MESSAGE,
                            team.Name
                        )
                    );
                }

                targetDepartmentOfTeam.Teams.Add(team);
                team.Department = targetDepartmentOfTeam;
            }
        }

        public void Update(Team team, string propertyName, object propertyValueToSet)
        {
            try
            {
                string formattedTeamPropertyName = string.Join(string.Empty, propertyName.Split(" "));
                var teamPropertyInfo = team.GetType().GetProperty(formattedTeamPropertyName);
                var teamPropertyConversionType = teamPropertyInfo!.PropertyType;

                if (teamPropertyConversionType.IsPrimitive || teamPropertyConversionType == typeof(decimal) ||
                    teamPropertyConversionType == typeof(string)
                )
                {
                    var convertedTeamPropertyValueToSet = Convert.ChangeType(propertyValueToSet, teamPropertyConversionType);
                    team.GetType().GetProperty(formattedTeamPropertyName)!.SetValue(team, convertedTeamPropertyValueToSet);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(string.Format(
                        CommandsMessagesConstants.CHANGED_TEAM_OF_STARTUP_COMPANY_SUCCESS_MESSAGE,
                        team.Name,
                        propertyName,
                        propertyValueToSet
                    ));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessagesConstants.INPUT_INCORRECT_CHARACTERISTIC_TYPE_EXCEPTION_MESSAGE,
                            CommandsMessagesConstants.CHANGE_TEAM_CONCRETE_COMMAND_ARGUMENTS_PATTERN
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

        public void Remove(Team team, params object[] entityRemovalArguments)
        {
            var departmentOfTeam = StartupCompany.Departments.Where(d => d.Teams.Contains(team)).FirstOrDefault();
            departmentOfTeam?.Teams.Remove(team);
        }

        public bool Exists(Team teamToFind, params object[] entityExistenceArguments)
        {
            string departmentName = (string)entityExistenceArguments[0];
            var departmentOfTeam = StartupCompany.Departments.Where(d => d.Name == departmentName).FirstOrDefault();

            return departmentOfTeam == null
                ? throw new NonExistingStartupCompanyManagerEntityException(
                    string.Format(ExceptionMessagesConstants.NON_EXISTING_DEPARTMENT_EXCEPTION_MESSAGE, departmentName)
                  )
                : departmentOfTeam.Teams.Contains(teamToFind);
        }
    }
}
