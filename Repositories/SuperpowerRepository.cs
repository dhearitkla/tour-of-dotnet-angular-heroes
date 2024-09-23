using Microsoft.EntityFrameworkCore;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;

namespace tour.of.dotnet.angular.heroes.Repositories;

public class SuperpowerRepository : ISuperpowersRepository
{
    private readonly HeroContext _context;

    public SuperpowerRepository(HeroContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Superpower> GetSuperpowers()
    {
        return _context.Superpowers.ToList();
    }

    public IEnumerable<Superpower> SearchSuperpowers(string searchTerm)
    {
        var superpowers = (from superpower in _context.Superpowers
            where searchTerm.Any(s => superpower.Name.Contains(s))
            select superpower).ToList();

        return superpowers;
    }

    public Superpower? GetSuperpowerById(Guid superpowerId)
    {
        return _context.Superpowers.Find(superpowerId);
    }

    public void InsertSuperpower(Superpower superpower)
    {
        _context.Superpowers.Add(superpower);
    }

    public void DeleteSuperpower(Guid superpowerId)
    {
        var superpower = _context.Superpowers.Find(superpowerId);
        if (superpower != null)
        {
            _context.Superpowers.Remove(superpower);
        }
    }

    public void UpdateSuperpower(Superpower superpower)
    {
        _context.Entry(superpower).State = EntityState.Modified;
    }

    public void ClearSuperpowers()
    {
        _context.Superpowers.RemoveRange(_context.Superpowers);

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