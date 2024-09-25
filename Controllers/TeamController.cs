using Microsoft.AspNetCore.Mvc;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ILogger<TeamController> logger, ITeamService teamService)
    {
        _teamService = teamService;
        
    }

    [HttpGet]
    public IEnumerable<Team> Get()
    {
        return _teamService.GetAllTeams();
    }
    
    [HttpGet("{id:Guid}")]
    public ActionResult<Team> Get([FromRoute]Guid id)
    {
        var team = _teamService.GetTeamById(id);
        return team == null ? NotFound() : team;
    }
    
    [HttpGet("Search")]
    public IEnumerable<Team> Search([FromQuery]string name)
    {
        return _teamService.SearchTeamsByName(name);
    }
    
    [HttpPut]
    public void Update(Team team)
    {
        _teamService.UpdateTeam(team);
    }
    
    [HttpPost]
    public void Add(Team team)
    {
        _teamService.AddTeam(team);
    }
    
    [HttpDelete("{id:Guid}")]
    public void Delete(Guid id)
    {
        _teamService.DeleteTeamById(id);
    }
}