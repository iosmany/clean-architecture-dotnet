using ecommerce.core;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.application.Persistence;

public interface IRepository<E> where E: class
{
    DbSet<E> Set();
    ValueTask<E?> GetByIdAsync(long id, CancellationToken? cancellationToken= null);
    Task<IEnumerable<E>> GetAllAsync(CancellationToken? cancellationToken= null);
}
