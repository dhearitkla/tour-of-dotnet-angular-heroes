using Microsoft.EntityFrameworkCore;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;

namespace tour.of.dotnet.angular.heroes.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly HeroContext _context;
    private readonly ILogger<HeroRepository> _logger;
    
    public HeroRepository(HeroContext context, ILogger<HeroRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IEnumerable<Hero> GetHeroes()
    {
        return _context.Heroes.Select(hero => new Hero()
        {
            HeroId = hero.HeroId,
            Name = hero.Name,
            Superpowers = hero.Superpowers, // includes Superpowers, but not Superpowers.Heroes 
            TeamId = hero.TeamId,
            Team = hero.Team,
        }).ToList();
    }

    public IEnumerable<Hero> SearchHeroes(string searchTerm)
    {
        var heroes = (from hero in _context.Heroes
            where hero.Name.Contains(searchTerm)
            select new Hero()
            {
                HeroId = hero.HeroId,
                Name = hero.Name,
                Superpowers = hero.Superpowers, // includes Superpowers, but not Superpowers.Heroes 
                TeamId = hero.TeamId,
                Team = hero.Team,
            }).ToList();

        return heroes;
    }

    public Hero? GetHeroById(Guid id)
    {
       var hero =  _context.Heroes.Select(hero => new Hero()
        {
            HeroId = hero.HeroId,
            Name = hero.Name,
            Superpowers = hero.Superpowers, // includes Superpowers, but not Superpowers.Heroes 
            TeamId = hero.TeamId,
            Team = hero.Team,
        }).Where( r => r.HeroId == id);
       
       return hero.FirstOrDefault();
    }

    public void InsertHero(Hero hero)
    {
        _context.Heroes.Add(hero);
    }

    public void DeleteHero(Guid heroId)
    {
        var hero = _context.Heroes.Find(heroId);
        //manage deletion of superpower before the hero is deleted
        if (hero != null)
        {
            _context.Heroes.Remove(hero);
        }
    }

    public void UpdateHero(Hero hero)
    {
        // var anotherInstanceOfHero = _context.Heroes.Include(x => x.Superpowers).FirstOrDefault(x => x.HeroId == hero.HeroId);
        // anotherInstanceOfHero.CopyHero(hero);
        // _logger.LogInformation($"Superpower to be cleared: ({hero.HeroId}, {hero.Superpowers.FirstOrDefault().SuperpowerId})");
        
        
        
        // hero.Superpowers = hero.Superpowers.Except(anotherInstanceOfHero.Superpowers, new SuperpowerIdComparer()).ToList();
        
        // _context.Entry(hero).State = EntityState.Modified;
        _context.Heroes.Update(hero);
        _context.SaveChanges();
        
        // foreach (var superpower in superpowersOfHero)
        // {
        //     _logger.LogInformation($"Superpower: {superpower.Name}");
        //     hero.Superpowers.Add(superpower);
        // }
        // _context.Update(hero);
        // _context.SaveChanges();
        // _context.Entry(hero).State = EntityState.Modified;
        // _context.Heroes.Update(hero);
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
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}