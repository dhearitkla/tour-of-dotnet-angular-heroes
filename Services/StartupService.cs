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
        new Hero("Dr. Doom", new List<Superpower>()),
        new Hero("Bombasto", new List<Superpower>()),
        new Hero("Celeritas", new List<Superpower>()),
        new Hero("Magneta", new List<Superpower>()),
        new Hero("RubberMan", new List<Superpower>()),
        new Hero("Dynama", new List<Superpower>()),
        new Hero("Dr. IQ", new List<Superpower>()),
        new Hero("Magma", new List<Superpower>()),
        new Hero("Tornado", new List<Superpower>()),
        new Hero("Dr. Nice", new List<Superpower>()),
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
    }
    
}