using StartupCompanyManager.Constants;
using StartupCompanyManager.Infrastructure.Exceptions;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Models;

namespace StartupCompanyManager.Core.Facade.SubSystems
{
    public class TeamsSubSystem
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsSubSystem(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team AddTeamToDepartment(string name, string department)
        {
            Team foundTeam = _teamRepository.GetByCondition(t => t.Name == name);

            bool doesTeamExist = foundTeam != null;

            if (doesTeamExist)
            {
                string existingTeamExceptionMessage = string.Format(
                    ExceptionMessagesConstants.EXISTING_TEAM_EXCEPTION_MESSAGE, name
                );

                throw new ExistingStartupCompanyManagerEntityException(existingTeamExceptionMessage);
            }

            Team teamToAdd = new(name);

            _teamRepository.Add(teamToAdd, department);

            return teamToAdd;
        }

        public void ChangeTeamCharacteristic(string name, string characteristic, object value)
        {
            Team teamToUpdate = _teamRepository.GetByCondition(t => t.Name == name);

            if (teamToUpdate == null)
            {
                string nonExistingTeamExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingTeamExceptionMessage);
            }

            _teamRepository.Update(teamToUpdate, characteristic, value);
        }

        public void RemoveTeam(string name)
        {
            Team teamToRemove = _teamRepository.GetByCondition(t => t.Name == name);

            if (teamToRemove == null)
            {
                string nonExistingTeamExceptionMessage = string.Format(
                    ExceptionMessagesConstants.NON_EXISTING_TEAM_EXCEPTION_MESSAGE, name
                );

                throw new NonExistingStartupCompanyManagerEntityException(nonExistingTeamExceptionMessage);
            }

            _teamRepository.Remove(teamToRemove);
        }
    }
}
