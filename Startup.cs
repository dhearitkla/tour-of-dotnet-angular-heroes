﻿using tour.of.dotnet.angular.heroes.Entities.Models;
using tour.of.dotnet.angular.heroes.Repositories;
using tour.of.dotnet.angular.heroes.Repositories.Interfaces;
using tour.of.dotnet.angular.heroes.Services;
using tour.of.dotnet.angular.heroes.Services.Interfaces;

namespace tour.of.dotnet.angular.heroes;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddDbContext<HeroContext>();
        services.AddControllers();
        services.AddControllers().AddNewtonsoftJson();
        services.AddScoped<IHeroRepository, HeroRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IStartupService, StartupService>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
        
        app.UseStaticFiles();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        using var scope = app.ApplicationServices.CreateScope();
        var startupService = scope.ServiceProvider.GetRequiredService<IStartupService>;
        startupService.Invoke().InitLoadOfHeroesAndTeams();
    }
 
}