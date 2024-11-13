using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Customer.Queries
{
    sealed class CustomersGetList : ICustomersGetList
    {
        readonly IDatabaseService _databaseService;
        public CustomersGetList(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async IAsyncEnumerable<CustomerModel> GetAsync(Func<domain.Entities.Customers.Customer, bool> predicate)
        {
            var query = _databaseService.Customers.Where(predicate).AsQueryable();

            foreach (var customer in await query.ToListAsync())
            {
                yield return new CustomerModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                };
            }
        }
    }
}
