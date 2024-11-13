using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ecommerce.application
{
    public interface IDatabaseService
    {
        DbSet<domain.Entities.Customers.Customer> Customers { get; }
        DbSet<domain.Entities.Products.Product> Products { get; }
        DbSet<domain.Entities.Sales.Sale> Sales { get; }
        DbSet<domain.Entities.Sales.SaleLine> SaleLine { get; }

        IDbContextTransaction BeginTransaction();
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
