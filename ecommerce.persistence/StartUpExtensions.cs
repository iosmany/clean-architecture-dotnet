using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.persistence
{
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
}
