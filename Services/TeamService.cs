using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class TeamService : ITeamService
{
    private readonly ILogger<TeamService> _logger;
    private readonly ITeamRepository _teamRepository;

    public TeamService(ILogger<TeamService> logger, ITeamRepository teamRepository)
    {
        _logger = logger;
        _teamRepository = teamRepository;
        
    }
    public IEnumerable<Team> GetAllTeams()
    {
        _logger.LogDebug("Getting all teams");
        return _teamRepository.GetTeams();
    }

    public Team? GetTeamById(Guid id)
    {
        _logger.LogDebug($"Getting team by id: {id}");
        return _teamRepository.GetTeamById(id);
    }

    public IEnumerable<Team> SearchTeamsByName(string name)
    {
        _logger.LogDebug($"Getting teams by name containing the string: {name}");
        return _teamRepository.SearchTeams(name);
    }

    public void UpdateTeam(Team team)
    {
        _logger.LogDebug($"Updating team: {team}");
        _teamRepository.UpdateTeam(team);
        _teamRepository.Save();
    }

    public void AddTeam(Team team)
    {
        _logger.LogDebug($"Adding team: {team}");
        _teamRepository.InsertTeam(team);
        _teamRepository.Save();
    }

    public void DeleteTeamById(Guid id)
    {
        _logger.LogDebug($"Deleting team by id: {id}");
        _teamRepository.DeleteTeam(id);
        _teamRepository.Save();
    }
}