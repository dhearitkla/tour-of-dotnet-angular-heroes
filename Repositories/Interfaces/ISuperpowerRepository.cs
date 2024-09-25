using tour.of.dotnet.angular.heroes.Entities.Models;

namespace tour.of.dotnet.angular.heroes.Repositories.Interfaces;

public interface ISuperpowerRepository : IDisposable
{
    IEnumerable<Superpower> GetSuperpowers();
    IEnumerable<Superpower> SearchSuperpowers(string searchTerm);
    Superpower? GetSuperpowerById(Guid superpowerId);
    void InsertSuperpower(Superpower superpower);
    void DeleteSuperpower(Guid superpowerId);
    void UpdateSuperpower(Superpower superpower);
    public void ClearSuperpowers();
    void Save();
}