namespace tour.of.dotnet.angular.heroes.Entities.Models;

public class Superpower
{
    public Guid SuperpowerId { get; set; }
    public string? Name { get; set; }
    public SuperpowerGrade Grade { get; set; }
    public SuperpowerClassification Classification { get; set; }
    public List<Hero>? Heroes { get;} = new();
    
    // public ICollection<HeroSuperpower> HeroSuperpowers { get; set; }


    /**
     * Calculates the power points based on hero's superpowers.
     */
    public static int CalculatePowerPoints(Hero hero)
    {
        var powerPoints = 0;
        hero.Superpowers.ForEach(power =>
        {
            powerPoints += power.Grade switch
            {
                SuperpowerGrade.GradeD => 100,
                SuperpowerGrade.GradeC => 1000,
                SuperpowerGrade.GradeB => 2000,
                SuperpowerGrade.GradeA => 3000,
                SuperpowerGrade.Archon => 10000,
                _ => throw new Exception($"Unknown super power grade: {nameof(power.Grade)}")
            };
        });
        return powerPoints;
    }
}

/**
 * Borrowed from https://www.reddit.com/r/worldbuilding/comments/678yzd/classes_of_superpowers/
 */
public enum SuperpowerGrade
{
    GradeD, GradeC, GradeB, GradeA, Archon    
}

/**
 * Borrowed from https://www.reddit.com/r/worldbuilding/comments/678yzd/classes_of_superpowers/
 */
public enum SuperpowerClassification
{
    Offensive, Defensive, Supportive
}

public class SuperpowerIdComparer : IEqualityComparer<Superpower>
{
    public int GetHashCode(Superpower? superpower)
    {
        return superpower == null ? 0 : superpower.SuperpowerId.GetHashCode();
    }

    public bool Equals(Superpower? x1, Superpower? x2)
    {
        if (object.ReferenceEquals(x1, x2))
        {
            return true;
        }
        if (object.ReferenceEquals(x1, null) ||
            object.ReferenceEquals(x2, null))
        {
            return false;
        }
        return x1.SuperpowerId == x2.SuperpowerId;
    }
}

