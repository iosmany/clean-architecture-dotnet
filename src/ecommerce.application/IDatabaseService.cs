using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ecommerce.application
{
    public interface IDatabaseService : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        IDbContextTransaction BeginTransaction();
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess=true, CancellationToken cancellationToken = default);
    }
}
