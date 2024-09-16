using tour_of_dotnet_angular_heros.Entities.Models;
using tour_of_dotnet_angular_heros.Repositories;
using tour_of_dotnet_angular_heros.Repositories.Interfaces;

namespace tour_of_dotnet_angular_heros;

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
        services.AddScoped<IHeroRepository, HeroRepository>();
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
    }
 
}