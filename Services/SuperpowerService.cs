using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class SuperpowerService : ISuperpowerService
{
    private readonly ILogger<SuperpowerService> _logger;
    private readonly ISuperpowerRepository _superpowerRepository;

    public SuperpowerService(ILogger<SuperpowerService> logger, ISuperpowerRepository superpowerRepository)
    {
        _logger = logger;
        _superpowerRepository = superpowerRepository;
        
    }
    public IEnumerable<Superpower> GetAllSuperpowers()
    {
        _logger.LogDebug("Getting all superpowers");
        return _superpowerRepository.GetSuperpowers();
    }

    public Superpower? GetSuperpowerById(Guid id)
    {
        _logger.LogDebug($"Getting superpower by id: {id}");
        return _superpowerRepository.GetSuperpowerById(id);
    }

    public IEnumerable<Superpower> SearchSuperpowersByName(string name)
    {
        _logger.LogDebug($"Getting superpowers by name containing the string: {name}");
        return _superpowerRepository.SearchSuperpowers(name);
    }

    public void UpdateSuperpower(Superpower superpower)
    {
        _logger.LogDebug($"Updating superpower: {superpower}");
        _superpowerRepository.UpdateSuperpower(superpower);
        _superpowerRepository.Save();
    }

    public void AddSuperpower(Superpower superpower)
    {
        _logger.LogDebug($"Adding superpower: {superpower}");
        _superpowerRepository.InsertSuperpower(superpower);
        _superpowerRepository.Save();
    }

    public void DeleteSuperpowerById(Guid id)
    {
        _logger.LogDebug($"Deleting superpower by id: {id}");
        _superpowerRepository.DeleteSuperpower(id);
        _superpowerRepository.Save();
    }
}