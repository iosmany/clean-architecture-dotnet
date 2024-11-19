using ecommerce.persistence.Shared;

namespace ecommerce.persistence.Customer;

using domain.Entities.Customers;
using application;
using Microsoft.EntityFrameworkCore;
using application.Persistence;

class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDatabaseService databaseService) : base(databaseService)
    {
    }

    public async Task<Customer?> GetByEmailAsync(string email)
        => await Set().FirstOrDefaultAsync(c => c.Email.Value == email);
}
