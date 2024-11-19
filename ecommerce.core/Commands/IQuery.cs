
namespace ecommerce.core.Commands;

public interface IQuery<Rp>
{
    Task<Rp> ExecuteAsync(CancellationToken cancellationToken);
}

public interface IQuery<Rq, Rp>
{
    Task<Rp> ExecuteAsync(Rq request, CancellationToken cancellationToken);
}
