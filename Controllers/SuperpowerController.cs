using Microsoft.AspNetCore.Mvc;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Controllers;

[ApiController]
[Route("[controller]")]
public class SuperpowerController : ControllerBase
{
    private readonly ISuperpowerService _superpowerService;

    public SuperpowerController(ILogger<SuperpowerController> logger, ISuperpowerService superpowerService)
    {
        _superpowerService = superpowerService;
        
    }

    [HttpGet]
    public IEnumerable<Superpower> Get()
    {
        return _superpowerService.GetAllSuperpowers();
    }
    
    [HttpGet("{id:Guid}")]
    public ActionResult<Superpower> Get([FromRoute]Guid id)
    {
        var superpower = _superpowerService.GetSuperpowerById(id);
        return superpower == null ? NotFound() : superpower;
    }
    
    [HttpGet("Search")]
    public IEnumerable<Superpower> Search([FromQuery]string name)
    {
        return _superpowerService.SearchSuperpowersByName(name);
    }
    
    [HttpPut]
    public void Update(Superpower superpower)
    {
        _superpowerService.UpdateSuperpower(superpower);
    }
    
    [HttpPost]
    public void Add(Superpower superpower)
    {
        _superpowerService.AddSuperpower(superpower);
    }
    
    [HttpDelete("{id:Guid}")]
    public void Delete(Guid id)
    {
        _superpowerService.DeleteSuperpowerById(id);
    }
}