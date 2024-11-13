using ecommerce.application.Customer;
using ecommerce.core;
using LanguageExt;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static LanguageExt.Prelude;

namespace ecommerce.domain.Entities.Customers
{
    [TestFixture]
    internal class CustomerFactoryTests
    {
        [Test]
        public void ShouldCreateCustomer()
        {
            var factory = new CustomerFactory();
            Assert.That(factory, Is.Not.Null);
            var customer = factory.Create("John Doe", "");
            customer.BiBind<Customer>(
                ok =>
                {
                    Assert.That(ok.FirstName, Is.EqualTo("John Doe"));
                    return ok;
                },
                ko =>
                {
                    throw new Exception("Should not be here");
                });
        }

        [Test]
        public void ShouldThrowAnErrorWhenCustomerNameIsEmpty()
        {
            var factory = new CustomerFactory();
            var customer = factory.Create("", "");
            customer.BiBind<Customer>(
                ok =>
                {
                    throw new Exception("Should not be here");
                },
                ko =>
                {
                    Assert.That(ko.Count, Is.GreaterThan(0));
                    var errorMessage = ko.FirstOrDefault();
                    Assert.That(errorMessage, Is.Not.Null);
                    Assert.That(errorMessage?.Message, Is.EqualTo("First name is required"));
                    return Left(ko);
                });
        }
    }
}
