using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class HeroContext : DbContext
{
    public DbSet<Team>? Teams { get; set; }
    public DbSet<Hero>? Heroes { get; set; }
    public DbSet<SuperPower>? SuperPowers { get; set; } 

    public string DbPath { get; }

    public HeroContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "heroes.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Team
{
    public int TeamId { get; set; }
    public string? Name { get; set; }
    public string? Purpose { get; set; }
    public int? Power { get; set; }

    public List<Hero> Heroes { get; } = new();
}

public class Hero
{
    public int HeroId { get; set; }
    public string? Name { get; set; }
    
    public List<SuperPower> SuperPowers { get; } = new();
    public int? Power { get; set; }

    public int TeamId { get; set; }
    public Team? Team { get; set; }
}

public class SuperPower
{
    public int SuperPowerId { get; set; }
    public string? Name { get; set; }
    public SuperPowerGrade Grade { get; set; }
    public SuperPowerClassification Classification { get; set; }
}

/**
 * Borrowed from https://www.reddit.com/r/worldbuilding/comments/678yzd/classes_of_superpowers/
 */
public enum SuperPowerGrade
{
    GradeD, GradeC, GradeB, GradeA, Archon    
}

/** 
 * Borrowed from https://www.reddit.com/r/worldbuilding/comments/678yzd/classes_of_superpowers/
 */
public enum SuperPowerClassification
{
    Offensive, Defensive, Support
}