using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Services.Interfaces;

public interface IHeroService
{
    public IEnumerable<Hero> GetAllHeroes();
    public Hero? GetHeroById(Guid id);
    public IEnumerable<Hero> SearchHeroesByName(string name);
    public void UpdateHero(Hero hero);
    public void AddHero(Hero hero);
    public void DeleteHeroById(Guid id);
}