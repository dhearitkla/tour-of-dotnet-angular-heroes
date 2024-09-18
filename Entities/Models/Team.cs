﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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