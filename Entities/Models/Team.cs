namespace tour_of_dotnet_angular_heros.Entities.Models;

public class Team
{
    public int TeamId { get; set; }
    public string? Name { get; set; }
    public string? Purpose { get; set; }
    public int? PowerPoints { get; }

    public List<Hero> Heroes { get; } = new();
    
    public Team(string name, string purpose)
    {
        this.Name = name;
        this.Purpose = purpose;
    }
    
    public Team(string name, string purpose, List<Hero> heroes)
    {
        this.Name = name;
        this.Purpose = purpose;
        this.Heroes = heroes;
    }
}