using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.persistence;

public static class StartUpExtensions
{
    public static void AddOwnDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var engine = Enum.Parse(typeof(Engine), configuration["Engine"] ?? nameof(Engine.InMemory));
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DbContextService>(options =>
        {
            
            options.UseSqlServer("Server=.;Database=ecommerce;Trusted_Connection=True;");
        });
    }

}
