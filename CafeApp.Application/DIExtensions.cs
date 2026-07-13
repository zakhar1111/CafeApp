using CafeApp.Application.Bookings;
using CafeApp.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Application;

public static class DIExtensions
{
    public static IServiceCollection AddCafeApplication(this IServiceCollection services,IConfiguration config)
    {
        services.AddScoped<IDomainEventDispatcher,DomainEventDispatcher>();

        services.AddScoped<IDomainEventHandler<BookingConfirmed>,BookingConfirmedHandler>();

        services.AddScoped<IDomainEventHandler<BookingCreated>,BookingCreatedHandler>();

        return services;
    }
}
