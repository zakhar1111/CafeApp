using CafeApp.Domain.Repositories;
using CafeApp.Infrastructure.Repositories;
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

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        return services;
    }
}
