namespace tour_of_dotnet_angular_heros.Entities.Models;

public class Superpower
{
    public int SuperpowerId { get; set; }
    public string? Name { get; set; }
    public SuperpowerGrade Grade { get; set; }
    public SuperpowerClassification Classification { get; set; }
    
    /**
     * Calculates the power points based on hero's superpowers.
     */
    public static int CalculatePowerPoints(Hero hero)
    {
        var powerPoints = 0;
        hero.Superpowers.ForEach(power =>
        {
            switch (power.Grade)
            {
                case SuperpowerGrade.GradeD:
                    powerPoints += 100;
                    break;
                    
                case SuperpowerGrade.GradeC:
                    powerPoints += 1000;
                    break;
                    
                case SuperpowerGrade.GradeB:
                    powerPoints += 2000;
                    break;
                    
                case SuperpowerGrade.GradeA:
                    powerPoints += 3000;
                    break;
                    
                case SuperpowerGrade.Archon:
                    powerPoints += 10000;
                    break;
                
                default:
                    throw new Exception($"Unknown super power grade: {nameof(power.Grade)}");
            }
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
    Offensive, Defensive, Support
}

