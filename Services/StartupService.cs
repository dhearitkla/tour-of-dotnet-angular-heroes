using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class StartupService : IStartupService
{
    
    private readonly ILogger<StartupService> _logger;
    private readonly IHeroRepository _heroRepository;
    private readonly ITeamRepository _teamRepository;

    public StartupService(ILogger<StartupService> logger, IHeroRepository heroRepository, ITeamRepository teamRepository)
    {
        _logger = logger;
        _heroRepository = heroRepository;
        _teamRepository = teamRepository;
    }
    
    private static readonly List<Hero> InitHeroes = new()
    {
        new Hero { Name = "Dr. Doom" },
        new Hero { Name = "Bombasto" },
        new Hero { Name = "Celeritas" },
        new Hero { Name = "Magneta" },
        new Hero { Name = "RubberMan" },
        new Hero { Name = "Dynama"},
        new Hero { Name = "Dr. IQ" },
        new Hero { Name = "Magma" },
        new Hero { Name = "Tornado"},
        new Hero { Name = "Dr. Nice" },
    };

    private static readonly List<Team> InitTeams = new()
    {
        new Team("Doom Squad", "Wreck havoc on the Earth", InitHeroes.GetRange(0,5)),
        new Team("Weather Vanes", "Terraform the Earth in case of disaster", InitHeroes.GetRange(5,5)),
    };


    public void InitLoadOfHeroesAndTeams()
    {
        ClearDatabase();
        foreach (var team in InitTeams)
        {
            this._teamRepository.InsertTeam(team);
        }
        this._teamRepository.Save();
        
    }

    private void ClearDatabase()
    {
        this._heroRepository.ClearHeroes();
        this._teamRepository.ClearTeams();
        this._heroRepository.Save();
        this._teamRepository.Save();
    }
    
}