using ecommerce.application;
using ecommerce.domain.Entities.Products;
using ecommerce.domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace ecommerce.persistence
{
    internal sealed class DbContextService : DbContext, IDatabaseService
    {
        /// <summary>
        /// Gets or sets the DbSet of Customers.
        /// </summary>
        public DbSet<domain.Entities.Customers.Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Sales.
        /// </summary>
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of SaleLine.
        /// </summary>
        public DbSet<SaleLine> SaleLine { get; set; }

        readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the DbContextService class with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DbContextService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Initializes a new instance of the DbContextService class with the specified options and configuration.
        /// </summary>
        /// <param name="options">The options for the DbContext.</param>
        /// <param name="configuration">The configuration.</param>
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

        /// <summary>
        /// Begins a new database transaction.
        /// Simple transactions are the least restrictive. They allow dirty reads, non-repeatable reads, and phantom reads.
        /// </summary>
        /// <returns>The started database transaction.</returns>
        public IDbContextTransaction BeginTransaction()
            => Database.BeginTransaction();

        /// <summary>
        /// Begins a new database transaction with the specified isolation level of ReadCommitted.
        /// ReadCommited transactions are the most common isolation level in most systems. It prevents dirty reads and non-repeatable reads.
        /// </summary>
        /// <returns>The started database transaction.</returns>
        public IDbContextTransaction BeginTransactionReadCommit()
            => Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

        /// <summary>
        /// Begins a new database transaction with the specified isolation level of Serializable.
        /// Serializable transactions are the most restrictive. They require that the transactions are serializable.
        /// </summary>
        /// <returns>The started database transaction.</returns>
        public IDbContextTransaction BeginTransactionSerializable()
            => Database.BeginTransaction(System.Data.IsolationLevel.Serializable);

        /// <summary>
        /// Saves all changes made in this context to the database asynchronously.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indicates whether to accept all changes on success.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public override int SaveChanges()
            => base.SaveChanges();
    }
}
