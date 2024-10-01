using Microsoft.EntityFrameworkCore;

namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class HeroSuperpower
{
    public Guid HeroId { get; set; }
    public Guid SuperpowerId { get; set; }
    
    public Hero Hero { get; set; }
    public Superpower Superpower { get; set; }
}