using ecommerce.application;
using ecommerce.application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.persistence.Shared;

class Repository<E> : IRepository<E> where E : class
{
    readonly IDatabaseService _databaseService;
    public Repository(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public DbSet<E> Set() => _databaseService.Set<E>(); 

    public async ValueTask<E?> GetByIdAsync(long id, CancellationToken? cancellationToken = null)
        => await Set().FindAsync(id);

    public async Task<IEnumerable<E>> GetAllAsync(CancellationToken? cancellationToken = null)
        => await Set().ToListAsync();


}
