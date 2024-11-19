using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.persistence.Customer;

using ecommerce.domain.Entities;
using ecommerce.domain.Entities.Customers;
using LanguageExt.UnsafeValueAccess;

internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers")
            .HasKey(e => e.Id);

        builder.OwnsOne(e => e.Name, onb =>
        {
            onb.Property(p=>p.FirstName).HasColumnName("FirstName");
            onb.Property(p => p.LastName).HasColumnName("LastName");
        });

        builder.Property(e=> e.Email).HasConversion(p=> p.Value, v=>Email.Create(v).ValueUnsafe());
    }
}
