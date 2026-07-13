using CafeApp.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Application;

public sealed class DomainEventDispatcher
    : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(
        IEnumerable<IDomainEvent> events,
        CancellationToken ct)
    {
        foreach (var domainEvent in events)
        {
            await DispatchAsync(domainEvent, ct);
        }
    }

    private async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken ct)
    {
        var handlerType = typeof(IDomainEventHandler<>)
            .MakeGenericType(domainEvent.GetType());

        var handlers =
            _serviceProvider.GetServices(handlerType);

        foreach (dynamic handler in handlers)
        {
            await InvokeHandlerAsync(
                handler,
                domainEvent,
                ct);
        }
    }
    private static Task InvokeHandlerAsync(
        object handler,
        IDomainEvent domainEvent,
        CancellationToken cancellationToken)
    {
        return ((dynamic)handler).HandleAsync(
            (dynamic)domainEvent,
            cancellationToken);
    }
}