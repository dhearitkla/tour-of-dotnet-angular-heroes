using tour_of_dotnet_angular_heros.Entities.Models;

namespace tour_of_dotnet_angular_heros.Repositories.Interfaces;

public interface IHeroRepository : IDisposable
{
    IEnumerable<Hero> GetHeroes();
    IEnumerable<Hero> SearchHeroes(string searchTerm);
    Hero GetHeroById(int heroId);
    void InsertHero(Hero hero);
    void DeleteHero(int heroId);
    void UpdateHero(Hero hero);
    void Save();
}