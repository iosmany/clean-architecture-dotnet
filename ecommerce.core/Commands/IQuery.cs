
namespace ecommerce.core.Commands;

public interface IQuery
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}

public interface IQuery<R>
{
    Task ExecuteAsync(R request, CancellationToken cancellationToken);
}
