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