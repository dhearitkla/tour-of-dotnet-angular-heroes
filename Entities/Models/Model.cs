using Microsoft.EntityFrameworkCore;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class HeroContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Superpower> Superpowers { get; set; }
    public DbSet<HeroSuperpower> HeroSuperpowers { get; set; }
    
    private string ConnectionString { get; }
    public HeroContext(IConfiguration configuration)
    {
        ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("TourOfHeroes").Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(ConnectionString);
        options.EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>()
            .HasMany(e => e.Superpowers)
            .WithMany(e => e.Heroes)
            .UsingEntity<HeroSuperpower>();
    }
}