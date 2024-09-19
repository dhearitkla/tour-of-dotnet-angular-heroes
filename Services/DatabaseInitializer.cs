using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class DatabaseInitializer : IDatabaseInitializer
{
    
    private readonly ILogger<DatabaseInitializer> _logger;
    private readonly IHeroRepository _heroRepository;
    private readonly ITeamRepository _teamRepository;

    public DatabaseInitializer(ILogger<DatabaseInitializer> logger, IHeroRepository heroRepository, ITeamRepository teamRepository)
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
        new Team { Name = "Doom Squad", Purpose = "Wreck havoc on the Earth", Heroes = InitHeroes.GetRange(0,5) },
        new Team {Name = "Weather Vanes", Purpose = "Terraform the Earth in case of disaster", Heroes = InitHeroes.GetRange(5,5) },
    };


    public void Seed()
    {
        ClearDatabase();
        foreach (var team in InitTeams)
        {
            _teamRepository.InsertTeam(team);
        }
        _teamRepository.Save();
        
    }

    private void ClearDatabase()
    {
        _heroRepository.ClearHeroes();
        _teamRepository.ClearTeams();
        _heroRepository.Save();
        _teamRepository.Save();
    }
    
}