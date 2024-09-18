using Microsoft.EntityFrameworkCore;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;

namespace tour.of.dotnet.angular.heroes.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly HeroContext _context;
    
    public HeroRepository(HeroContext context)
    {
        this._context = context;
    }

    public IEnumerable<Hero> GetHeroes()
    {
        return _context.Heroes.ToList();
    }

    public IEnumerable<Hero> SearchHeroes(string searchTerm)
    {
        var heroes = (from hero in _context.Heroes
            where hero.Name.Contains(searchTerm)
            select hero).ToList();

        return heroes;
    }

    public Hero? GetHeroById(int id)
    {
        return _context.Heroes.Find(id);
    }

    public void InsertHero(Hero hero)
    {
        _context.Heroes.Add(hero);
    }

    public void DeleteHero(int heroId)
    {
        var hero = _context.Heroes.Find(heroId);
        if (hero != null)
        {
            _context.Heroes.Remove(hero);
        }
    }

    public void UpdateHero(Hero hero)
    {
        _context.Entry(hero).State = EntityState.Modified;
    }

    public void ClearHeroes()
    {
        _context.Heroes.RemoveRange(_context.Heroes);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}