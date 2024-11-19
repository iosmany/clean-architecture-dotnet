using ecommerce.domain.Entities.Core;
using ecommerce.domain.Entities.Customers;
using ecommerce.domain.Entities.Products;
using LanguageExt.Pretty;
using LanguageExt.UnsafeValueAccess;
using NUnit.Framework;

namespace ecommerce.domain.Entities.Sales
{

    [TestFixture]
    public class SaleTests
    {
        Customer CreateCustomer()
        {
            var email = Email.Create("johndoe@tets.com");
            Assert.That(email.IsRight, Is.True, "Email should be right expression");
            var name = Name.Create("John", "Doe");
            Assert.That(name.IsRight, Is.True, "Name should be right expression");
            return new Customer(email.ValueUnsafe(), name.ValueUnsafe());
        }
        Address CreateAddress()
        {
            var country = new Country("US", "United States");
            var address = Address.Create("some address", "", "FL", "33193", country);
            Assert.That(address.IsRight, Is.True, "Address should be right expression");
            return address.ValueUnsafe();
        }
        Product CreateProduct()
        {
            return new Product("Some product", 10.0m);
        }

        (Product, Sale, SaleLine) CreateSaleLine()
        {
            var sale = new Sale(CreateCustomer(), CreateAddress());
            var product = CreateProduct();
            var saleLine = new SaleLine(product, 1, sale);
            return (product, sale, saleLine);
        }

        /// <summary>
        /// create sales line using constructor
        /// </summary>
        [Test]
        public void Should_Create_SaleLine()
        {
            (Product product, Sale sale, SaleLine saleLine)= CreateSaleLine();
            Assert.That(saleLine, Is.Not.Null);
            Assert.That(saleLine.Sale, Is.EqualTo(sale));
            Assert.That(saleLine.Product, Is.EqualTo(product));
            Assert.That(saleLine.Quantity, Is.EqualTo(1));
        }

        /// <summary>
        /// update salesline quantity using update method
        /// </summary>
        [Test]
        public void Should_Update_SaleLine()
        {
            (Product product, Sale sale, SaleLine saleLine) = CreateSaleLine();
            
            saleLine.UpdateQuantity(2);
            
            Assert.That(saleLine.Quantity, Is.EqualTo(2));
        }


    }
}
