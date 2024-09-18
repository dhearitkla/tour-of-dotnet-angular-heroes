using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class Hero
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HeroId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<Superpower> Superpowers { get; } = new();
    public int PowerPoints { get; } = 0;

    public int TeamId { get; set; }
    public Team? Team { get; set; }

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