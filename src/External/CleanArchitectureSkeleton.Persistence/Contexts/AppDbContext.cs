using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CleanArchitectureSkeleton.Persistence.Contexts;

public sealed class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env}.json", true, true)
            .Build();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
}