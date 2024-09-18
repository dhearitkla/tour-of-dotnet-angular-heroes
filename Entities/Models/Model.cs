using Microsoft.EntityFrameworkCore;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class HeroContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Superpower> SuperPowers { get; set; }

    private string DbPath { get; }

    public HeroContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "heroes.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}