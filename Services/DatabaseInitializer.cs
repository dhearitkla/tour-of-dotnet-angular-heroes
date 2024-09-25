using Microsoft.EntityFrameworkCore;
using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes.Services;

public class DatabaseInitializer : IDatabaseInitializer
{
    
    private readonly ILogger<DatabaseInitializer> _logger;
    private readonly IHeroRepository _heroRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly ISuperpowerRepository _superpowerRepository;
    private static readonly Random Random = new Random();

    public DatabaseInitializer(ILogger<DatabaseInitializer> logger, IHeroRepository heroRepository, ITeamRepository teamRepository, ISuperpowerRepository superpowerRepository)
    {
        _logger = logger;
        _heroRepository = heroRepository;
        _teamRepository = teamRepository;
        _superpowerRepository = superpowerRepository;
    }
    
    private static readonly List<Superpower> InitSuperpowers = new()
    {
        new Superpower {Name = "Omnipotence", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.Archon},
        new Superpower {Name = "Immortality", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeA},
        new Superpower {Name = "Time Travel", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeA},
        new Superpower {Name = "Time Manipulation", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Flight", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Invisibility", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Telekinesis", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Teleportation", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Water Control", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Weather Control", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Heat Vision", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "X-Ray Vision", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeD},
        new Superpower {Name = "Phasing", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Plant Control", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Small Size", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeD},
        new Superpower {Name = "Anti-Gravity", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Creation", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeA},
        new Superpower {Name = "Hacking", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Magic", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeA},
        new Superpower {Name = "Necromancy", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeB},
        new Superpower {Name = "Luck", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Super Strength", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Space Survivability", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Invulnerability", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeA},
        new Superpower {Name = "Magnetism", Classification = SuperpowerClassification.Supportive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Natural Armor", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Large Size", Classification = SuperpowerClassification.Offensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Force Fields", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeC},
        new Superpower {Name = "Damage Transferal", Classification = SuperpowerClassification.Defensive, Grade = SuperpowerGrade.GradeB},
        
    };
    
    private static readonly List<Hero> InitHeroes = new()
    {
        new Hero { Name = "Dr. Doom", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(5).ToList() },
        new Hero { Name = "Bombasto", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(4).ToList() },
        new Hero { Name = "Celeritas", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(3).ToList() },
        new Hero { Name = "Magneta", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(2).ToList() },
        new Hero { Name = "RubberMan", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(1).ToList() },
        new Hero { Name = "Dynama", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(5).ToList() },
        new Hero { Name = "Dr. IQ", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(4).ToList() },
        new Hero { Name = "Magma", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(3).ToList() },
        new Hero { Name = "Tornado", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(2).ToList() },
        new Hero { Name = "Dr. Nice", Superpowers = InitSuperpowers.OrderBy(x => Random.Next()).Take(1).ToList() },
    };

    private static readonly List<Team> InitTeams = new()
    {
        new Team { Name = "Doom Squad", Purpose = "Wreck havoc on the Earth", Heroes = InitHeroes.GetRange(0,5) },
        new Team { Name = "Weather Vanes", Purpose = "Terraform the Earth in case of disaster", Heroes = InitHeroes.GetRange(5,5) },
    };

    


    public void Seed()
    {
        ClearDatabase();
        foreach (var team in InitTeams)
        {
            _teamRepository.InsertTeam(team);
        }
        _teamRepository.Save();
        
    }

    private void ClearDatabase()
    {
        _superpowerRepository.ClearSuperpowers();
        _heroRepository.ClearHeroes();
        _teamRepository.ClearTeams();
        _heroRepository.Save();
        _teamRepository.Save();
        _superpowerRepository.Save();
    }
}