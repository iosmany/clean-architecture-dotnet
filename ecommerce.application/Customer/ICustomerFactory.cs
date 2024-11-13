using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.core;
using LanguageExt;

namespace ecommerce.application.Customer
{
    using domain.Entities.Customers;
    interface ICustomerFactory
    {
        Either<IReadOnlyCollection<IError>, Customer> Create(string firstName, string? lastName = null)
        Either<IReadOnlyCollection<IError>, Customer> Deactivate(Customer entity);
    }
}
