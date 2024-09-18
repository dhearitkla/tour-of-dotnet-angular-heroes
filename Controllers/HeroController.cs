using Microsoft.AspNetCore.Mvc;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;

namespace tour.of.dotnet.angular.heroes.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private readonly ILogger<HeroController> _logger;
    private readonly IHeroRepository _heroRepository;

    public HeroController(ILogger<HeroController> logger, IHeroRepository heroRepository)
    {
        _logger = logger;
        _heroRepository = heroRepository;
        
    }

    [HttpGet]
    public IEnumerable<Hero> Get()
    {
        _logger.LogDebug("Getting all heroes");
        return _heroRepository.GetHeroes();;
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<Hero> Get([FromRoute]int id)
    {
        var hero = _heroRepository.GetHeroById(id);
        return hero == null ? NotFound() : hero;
    }
    
    [HttpGet("Search")]
    public IEnumerable<Hero> Search([FromQuery]string name)
    {
        return this._heroRepository.SearchHeroes(name);
    }
    
    [HttpPut]
    public void Update(Hero hero)
    {
        this._heroRepository.UpdateHero(hero);
        this._heroRepository.Save();
    }
    
    [HttpPost]
    public void Add(Hero hero)
    {
        this._heroRepository.InsertHero(hero);
        this._heroRepository.Save();
    }
    
    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        this._heroRepository.DeleteHero(id);
        this._heroRepository.Save();
    }
}