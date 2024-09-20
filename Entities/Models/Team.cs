using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TeamId { get; set; }
    public string? Name { get; set; }
    public string? Purpose { get; set; }
    public int? PowerPoints { get; }

    public List<Hero> Heroes { get; set; } = new();
}