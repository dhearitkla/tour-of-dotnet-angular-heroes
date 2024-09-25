using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Services.Interfaces;

public interface ISuperpowerService
{
    public IEnumerable<Superpower> GetAllSuperpowers();
    public Superpower? GetSuperpowerById(Guid id);
    public IEnumerable<Superpower> SearchSuperpowersByName(string name);
    public void UpdateSuperpower(Superpower superpower);
    public void AddSuperpower(Superpower superpower);
    public void DeleteSuperpowerById(Guid id);
}