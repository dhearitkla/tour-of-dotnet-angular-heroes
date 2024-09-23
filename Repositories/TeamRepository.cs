using Microsoft.EntityFrameworkCore;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;

namespace tour.of.dotnet.angular.heroes.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly HeroContext _context;
    
    public TeamRepository(HeroContext context)
    {
        _context = context;
    }

    public IEnumerable<Team> GetTeams()
    {
        return _context.Teams.ToList();
    }

    public IEnumerable<Team> SearchTeams(string searchTerm)
    {
        var heroes = (from team in _context.Teams
            where searchTerm.Any(s => team.Name.Contains(s))
            select team).ToList();

        return heroes;
    }

    public Team? GetTeamById(Guid teamId)
    {
        return _context.Teams.Find(teamId);
    }

    public void InsertTeam(Team team)
    {
        _context.Teams.Add(team);
    }

    public void DeleteTeam(Guid teamId)
    {
        var team = _context.Teams.Find(teamId);
        if (team != null)
        {
            _context.Teams.Remove(team);
        }
    }

    public void UpdateTeam(Team team)
    {
        _context.Entry(team).State = EntityState.Modified;
    }
    
    public void ClearTeams()
    {
        _context.Teams.RemoveRange(_context.Teams);
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