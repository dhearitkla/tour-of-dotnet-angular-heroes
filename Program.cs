using System;
using System.Linq;

using var db = new HeroContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new Team");
db.Add(new Team { Name = "Adjudicators", Purpose = "To Judge" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a Team");
var Team = db.Teams
    .OrderBy(b => b.TeamId)
    .First();

// Update
Console.WriteLine("Updating the Team and adding a Hero");
Team.Name = "Doom Kitties";
Team.Heroes.Add(
    new Hero { Name = "World Ender" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the Team");
db.Remove(Team);
db.SaveChanges();