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

        public Team GetByCondition(Func<Team, bool> entityFilterDelegate)
        {
            return StartupCompany.Departments.SelectMany(d => d.Teams).FirstOrDefault(entityFilterDelegate)!;
        }

        public ICollection<Team> GetAllByCondition(Func<Team, bool> entitiesFilterDelegate)
        {
            return StartupCompany.Departments.SelectMany(d => d.Teams).Where(entitiesFilterDelegate).ToList();
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
            Type propertyValueToSetType = propertyValueToSet.GetType();

            if (propertyValueToSetType.IsPrimitive || propertyValueToSetType == typeof(decimal) || 
                propertyValueToSetType == typeof(string)
            )
            {
                team.GetType().GetProperty(propertyName)!.SetValue(team, propertyValueToSet);
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

        public void Remove(Team team, params object[] entityRemovalArguments)
        {
            team.Department?.Teams.Remove(team);
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
