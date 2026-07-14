namespace CafeApp.Application;

public interface IOperationHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    Task<TResult?> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}
