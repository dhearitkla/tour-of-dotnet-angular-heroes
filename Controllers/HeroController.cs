using Microsoft.AspNetCore.Mvc;
using tour_of_dotnet_angular_heros.Entities.Models;
using tour_of_dotnet_angular_heros.Repositories.Interfaces;

namespace tour_of_dotnet_angular_heros.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private static readonly List<Hero> Heroes = new()
    {
        new Hero("Dr. Doom", new List<Superpower>(), 1),
        new Hero("Bombasto", new List<Superpower>(), 1),
        new Hero("Celeritas", new List<Superpower>(), 1),
        new Hero("Magneta", new List<Superpower>(), 1),
        new Hero("RubberMan", new List<Superpower>(), 1),
        new Hero("Dynama", new List<Superpower>(), 1),
        new Hero("Dr. IQ", new List<Superpower>(), 1),
        new Hero("Magma", new List<Superpower>(), 1),
        new Hero("Tornado", new List<Superpower>(), 1),
        new Hero("Dr. Nice", new List<Superpower>(), 1),
    };

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
        return Heroes;
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<Hero> Get([FromRoute]int id)
    {
        var hero = Heroes.Find(hero => hero.HeroId == id);
        return hero == null ? NotFound() : hero;
    }
    
    [HttpGet("search")]
    public IEnumerable<Hero> Search([FromQuery]string term)
    {
        return this._heroRepository.SearchHeroes(term);
    }
    
    [HttpPut]
    public void Update(Hero hero)
    {
        this._heroRepository.UpdateHero(hero);
    }
    
    [HttpPost]
    public void Add(Hero hero)
    {
        this._heroRepository.InsertHero(hero);
    }
    
    [HttpDelete]
    public void Delete(int id)
    {
        this._heroRepository.DeleteHero(id);
    }
}