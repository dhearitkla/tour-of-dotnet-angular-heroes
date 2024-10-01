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
        if (hero != null)
        {
            _context.Heroes.Remove(hero);
        }
    }

    public void UpdateHero(Hero updatedHero)
    {
        var existingHero = _context.Heroes.AsNoTracking().Include(x => x.Superpowers).FirstOrDefault(x => x.HeroId == updatedHero.HeroId);
        UpdateHeroSuperpowers(existingHero, updatedHero);

        updatedHero.Team = null; // Use team ID to update (not a clean workaround, could find way to update both obejects (team and teamId) on frotnend)
        _context.Heroes.Update(updatedHero);
        _context.SaveChanges();
    }
    
    private void UpdateHeroSuperpowers(Hero existingHero, Hero updatedHero)
    {
        _logger.LogInformation($"Updating Superpowers for {existingHero.Name}, {existingHero.HeroId}");
        
        var superpowersToAdd = updatedHero.Superpowers.Except(existingHero.Superpowers, new SuperpowerIdComparer()).ToList();
        var superpowersToDelete = existingHero.Superpowers.Except(updatedHero.Superpowers, new SuperpowerIdComparer()).ToList();
        updatedHero.Superpowers.Clear(); // If we don't clear the superpowers, the update later on will try and add them again (but that trick cannot be used for updating them without this UpdateHeroSuperpowers method)
        
        // Remove and add program types
        foreach (var superpower in superpowersToAdd)
        {
            var newHeroSuperpower = new HeroSuperpower()
            {
                SuperpowerId = superpower.SuperpowerId,
                HeroId = updatedHero.HeroId,
            };
            _logger.LogInformation($"Adding HeroSuperpower: ({newHeroSuperpower.SuperpowerId}, {newHeroSuperpower.HeroId})");
            _context.HeroSuperpowers.Add(newHeroSuperpower);
        }
        foreach (var superpower in superpowersToDelete) {
            var deletedHeroSuperpower = new HeroSuperpower()
            {
                SuperpowerId = superpower.SuperpowerId,
                HeroId = updatedHero.HeroId,
            };
            _logger.LogInformation($"Deleting HeroSuperpower: ({deletedHeroSuperpower.SuperpowerId}, {deletedHeroSuperpower.HeroId})");
            _context.HeroSuperpowers.Remove(deletedHeroSuperpower);
        }
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