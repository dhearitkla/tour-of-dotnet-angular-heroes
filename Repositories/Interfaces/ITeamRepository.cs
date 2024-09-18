using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Repositories.Interfaces;

public interface ITeamRepository : IDisposable
{
    IEnumerable<Team> GetTeams();
    IEnumerable<Team> SearchTeams(string searchTerm);
    Team? GetTeamById(int heroId);
    void InsertTeam(Team hero);
    void DeleteTeam(int heroId);
    void UpdateTeam(Team hero);
    public void ClearTeams();
    void Save();
}