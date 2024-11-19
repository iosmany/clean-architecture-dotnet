using ecommerce.domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.persistence.Sales;

public class SalesConfigurations : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales").HasKey(e => e.Id);

        builder.OwnsOne(p => p.Address, onb =>
        {
            onb.Property(p => p.Street).HasColumnName("Street");   
            onb.Property(p => p.City).HasColumnName("City");   
            onb.Property(p => p.State).HasColumnName("State");   
            onb.Property(p => p.ZipCode).HasColumnName("ZipCode");
            onb.Property(p => p.Phone).HasColumnName("Phone");   
            onb.HasOne(p => p.Country).WithMany().HasForeignKey("CountryId");
        });

        builder.Property(e => e.Customer).HasColumnName("CustomerId");

        builder.HasMany(e => e.SaleLines).WithOne(x=>x.Sale)
            .OnDelete(DeleteBehavior.Cascade)
            .Metadata.PrincipalToDependent?.SetPropertyAccessMode(PropertyAccessMode.Field); // This is a workaround for a bug in EF Core 5.0.0 that prevents the use of private setters in owned types

    }
}
