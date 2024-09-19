using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class HeroService : IHeroService
{
    private readonly ILogger<HeroService> _logger;
    private readonly IHeroRepository _heroRepository;

    public HeroService(ILogger<HeroService> logger, IHeroRepository heroRepository)
    {
        _logger = logger;
        _heroRepository = heroRepository;
        
    }
    public IEnumerable<Hero> GetAllHeroes()
    {
        _logger.LogDebug("Getting all heroes");
        return _heroRepository.GetHeroes();
    }

    public Hero? GetHeroById(int id)
    {
        _logger.LogDebug($"Getting hero by id: {id}");
        return _heroRepository.GetHeroById(id);
    }

    public IEnumerable<Hero> SearchHeroesByName(string name)
    {
        _logger.LogDebug($"Getting heroes by name containing the string: {name}");
        return _heroRepository.SearchHeroes(name);
    }

    public void UpdateHero(Hero hero)
    {
        _logger.LogDebug($"Updating hero: {hero}");
        _heroRepository.UpdateHero(hero);
        _heroRepository.Save();
    }

    public void AddHero(Hero hero)
    {
        _logger.LogDebug($"Adding hero: {hero}");
        _heroRepository.InsertHero(hero);
        _heroRepository.Save();
    }

    public void DeleteHeroById(int id)
    {
        _logger.LogDebug($"Deleting hero by id: {id}");
        _heroRepository.DeleteHero(id);
        _heroRepository.Save();
    }
}