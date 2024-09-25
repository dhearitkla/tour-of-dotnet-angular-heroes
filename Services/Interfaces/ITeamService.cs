using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Services.Interfaces;

public interface ITeamService
{
    public IEnumerable<Team> GetAllTeams();
    public Team? GetTeamById(Guid id);
    public IEnumerable<Team> SearchTeamsByName(string name);
    public void UpdateTeam(Team team);
    public void AddTeam(Team team);
    public void DeleteTeamById(Guid id);
}