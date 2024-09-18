using Microsoft.EntityFrameworkCore;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class HeroContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Superpower> SuperPowers { get; set; }

    private string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=127.0.0.1;Integrated Security=false;Initial Catalog='tour-heroes-dev-db';User Id='sa';Password='36x87#aj@84=4}j8';application name=TourOfHeroes");
}