using System;
using Microsoft.AspNetCore;

namespace tour.of.dotnet.angular.heroes;
public class Program
{
    
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }
    
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .CaptureStartupErrors(true)
            .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
}

// Note: This sample requires the database to be created before running.
// using var db = new HeroContext();


// Console.WriteLine($"Database path: {db.DbPath}.");
//
// // Create
// Console.WriteLine("Inserting a new Team");
// db.Add(new Team("Adjudicators", "To Judge" ));
// db.SaveChanges();
//
// // Read
// Console.WriteLine("Querying for a Team");
// var team = db.Teams
//     .OrderBy(b => b.TeamId)
//     .First();
//
// // Update
// Console.WriteLine("Updating the Team and adding a Hero");
// team.Name = "Doom Kitties";
// team.Heroes.Add(
//     new Hero("World Ender"));
// db.SaveChanges();
//
// // Delete
// Console.WriteLine("Delete the Team");
// db.Remove(team);
// db.SaveChanges();