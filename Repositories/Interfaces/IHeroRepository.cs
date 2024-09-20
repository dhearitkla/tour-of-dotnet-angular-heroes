using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Repositories.Interfaces;

public interface IHeroRepository : IDisposable
{
    IEnumerable<Hero> GetHeroes();
    IEnumerable<Hero> SearchHeroes(string searchTerm);
    Hero? GetHeroById(Guid heroId);
    void InsertHero(Hero hero);
    void DeleteHero(Guid heroId);
    void UpdateHero(Hero hero);
    void ClearHeroes();
    void Save();
}