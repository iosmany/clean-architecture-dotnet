using ecommerce.application;
using ecommerce.application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.persistence.Shared;

abstract class Repository<E> : IRepository<E> where E : class
{
    protected DbSet<E> Set => _databaseService.Set<E>();
    readonly IDatabaseService _databaseService;
    public Repository(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    public async IAsyncEnumerable<E> GetAllAsync()
    {
        await foreach (var row in Set)
            yield return row;
    }
    public async ValueTask<E?> GetByIdAsync(long id) => await Set.FindAsync(id);
}
