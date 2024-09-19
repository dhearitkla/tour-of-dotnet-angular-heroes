using Microsoft.AspNetCore.Mvc;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private readonly ILogger<HeroController> _logger;
    private readonly IHeroService _heroService;

    public HeroController(ILogger<HeroController> logger, IHeroService heroService)
    {
        _logger = logger;
        _heroService = heroService;
        
    }

    [HttpGet]
    public IEnumerable<Hero> Get()
    {
        return _heroService.GetAllHeroes();
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<Hero> Get([FromRoute]int id)
    {
        var hero = _heroService.GetHeroById(id);
        return hero == null ? NotFound() : hero;
    }
    
    [HttpGet("Search")]
    public IEnumerable<Hero> Search([FromQuery]string name)
    {
        return _heroService.SearchHeroesByName(name);
    }
    
    [HttpPut]
    public void Update(Hero hero)
    {
        _heroService.UpdateHero(hero);
    }
    
    [HttpPost]
    public void Add(Hero hero)
    {
        _heroService.AddHero(hero);
    }
    
    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _heroService.DeleteHeroById(id);
    }
}