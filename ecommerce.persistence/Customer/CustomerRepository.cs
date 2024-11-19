using ecommerce.persistence.Shared;

namespace ecommerce.persistence.Customer;

using domain.Entities.Customers;
using ecommerce.application;
using Microsoft.EntityFrameworkCore;

class CustomerRepository : Repository<Customer>
{
    public CustomerRepository(IDatabaseService databaseService) : base(databaseService)
    {
    }

    public async Task<Customer> GetByEmailAsync(string email)
        => await Set.FirstOrDefaultAsync(c => c.Email == email);
}
