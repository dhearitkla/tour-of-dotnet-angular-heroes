using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class Hero
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid HeroId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<Superpower> Superpowers { get; set; } = new();
    public int PowerPoints { get; set;  } = 0;

    public Guid TeamId { get; set; }
    public Team? Team { get; set; }

    public void CopyHero(Hero hero)
    {
        this.HeroId = hero.HeroId;
        this.Name = hero.Name;
        this.Superpowers = hero.Superpowers;
        this.PowerPoints = hero.PowerPoints;
        this.TeamId = hero.TeamId;
        this.Team = hero.Team;
    }


    // public Hero(string name, List<Superpower> superpowers)
    // {
    //     this.Name = name;
    //     this.Superpowers = superpowers;
    //     this.PowerPoints = Superpower.CalculatePowerPoints(this);
    //     
    //     // TeamFactory.getTeam(teamId).setHero(this);
    //     // this.Team = TeamFactory.getTeam(teamId);
    // }
}