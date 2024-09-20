using Microsoft.EntityFrameworkCore;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class HeroContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Superpower> SuperPowers { get; set; }
    public IConfiguration Configuration { get; }
    
    private string ConnectionString { get; }
    public HeroContext(IConfiguration configuration)
    {
        Configuration = configuration;
        ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("TourOfHeroes").Value;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);
}