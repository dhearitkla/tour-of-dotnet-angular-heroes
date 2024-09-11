using tour_of_dotnet_angular_heros.Entities.Models;

using var db = new HeroContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new Team");
db.Add(new Team("Adjudicators", "To Judge" ));
db.SaveChanges();

// Read
Console.WriteLine("Querying for a Team");
var team = db.Teams
    .OrderBy(b => b.TeamId)
    .First();

// Update
Console.WriteLine("Updating the Team and adding a Hero");
team.Name = "Doom Kitties";
team.Heroes.Add(
    new Hero("World Ender"));
db.SaveChanges();

// Delete
Console.WriteLine("Delete the Team");
db.Remove(team);
db.SaveChanges();