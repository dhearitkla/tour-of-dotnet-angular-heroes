namespace tour_of_dotnet_angular_heros.Entities.Models;

public class Hero
{
    public int HeroId { get; set; }
    public string Name { get; set; }
    
    public List<Superpower> Superpowers { get; } = new();
    public int PowerPoints { get;}

    public int TeamId { get; set; }
    public Team? Team { get; set; }
    
    public Hero(string name)
    {
        this.Name = name;
    }

    public Hero(string name, List<Superpower> superpowers, int teamId)
    {
        this.Name = name;
        this.Superpowers = superpowers;
        this.TeamId = teamId;
        this.PowerPoints = Superpower.CalculatePowerPoints(this);
        
        // TeamFactory.getTeam(teamId).setHero(this);
        // this.Team = TeamFactory.getTeam(teamId);
    }
}