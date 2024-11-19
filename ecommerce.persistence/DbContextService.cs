using ecommerce.application;
using ecommerce.domain.Entities.Categories;
using ecommerce.domain.Entities.Core;
using ecommerce.domain.Entities.Products;
using ecommerce.domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace ecommerce.persistence
{
    internal sealed class DbContextService : DbContext, IDatabaseService
    {
        public DbSet<domain.Entities.Customers.Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleLine> SaleLine { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }


        readonly IConfiguration _configuration;
        public DbContextService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContextService(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public IDbContextTransaction BeginTransaction()
            => Database.BeginTransaction();

        public IDbContextTransaction BeginTransactionReadCommit()
            => Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

        public IDbContextTransaction BeginTransactionSerializable()
            => Database.BeginTransaction(System.Data.IsolationLevel.Serializable);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        public override int SaveChanges()
            => base.SaveChanges();
    }
}
