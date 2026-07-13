using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection AddCafeInfrastructure(this IServiceCollection services,IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("Default")
                ));
        return services;
    }
}
