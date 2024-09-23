using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Repositories.Interfaces;

public interface ITeamRepository : IDisposable
{
    IEnumerable<Team> GetTeams();
    IEnumerable<Team> SearchTeams(string searchTerm);
    Team? GetTeamById(Guid teamId);
    void InsertTeam(Team team);
    void DeleteTeam(Guid teamId);
    void UpdateTeam(Team team);
    public void ClearTeams();
    void Save();
}