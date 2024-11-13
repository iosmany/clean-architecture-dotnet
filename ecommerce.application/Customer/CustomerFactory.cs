using ecommerce.application.Customer;
using ecommerce.core;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static LanguageExt.Prelude;

namespace ecommerce.domain.Entities.Customers
{
    sealed class CustomerFactory : ICustomerFactory
    {
        public Either<IReadOnlyCollection<IError>, Customer> Create(string firstName, string? lastName=null)
        {
            var customer = new Customer(firstName, lastName);
            var errors= customer.Validate();
            if (errors.Count > 0)
                return Left(errors);
            return customer;
        }

        public Either<IReadOnlyCollection<IError>, Customer> Deactivate(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
