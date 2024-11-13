using ecommerce.core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.Entities.Customers
{
    public sealed class CustomerTests
    {
        public CustomerTests()
        {
        }

        [Test]
        public void ShouldCreateCustomerWithName()
        {
            var customer = new Customer("Some name");
            Assert.That(customer.FirstName, Is.EqualTo("Some name"));
        }

        [Test]
        public void ShouldThrowAnErrorWhenCustomerNameIsEmpty()
        {
            var customer = new Customer("");
            Assert.That(customer.FirstName, Is.EqualTo(""));
            var errors= EntityValidationHelper.Validate(customer);
            Assert.That(errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldUpdateCustomer()
        {
            var customer = new Customer("Some name");
            customer.Update("New name", "Last", new DateTime(1990,1,1, 0,0, 0).ToDateOnly());
            Assert.That(customer.FirstName, Is.EqualTo("New name"));
        }
    }
}
