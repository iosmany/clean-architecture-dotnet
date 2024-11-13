using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.persistence.Customer
{
    internal class CustomerConfigurations : IEntityTypeConfiguration<ecommerce.domain.Entities.Customers.Customer>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ecommerce.domain.Entities.Customers.Customer> builder)
        {
            
        }
    }
}
