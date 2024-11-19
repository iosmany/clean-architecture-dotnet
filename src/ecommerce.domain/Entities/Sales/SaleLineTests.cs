using ecommerce.domain.Entities.Customers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ecommerce.domain.Entities.Sales
{
    using ecommerce.domain.Entities.Catalog.Categories;
    using ecommerce.domain.Entities.Core;
    using ecommerce.domain.Entities.Catalog.Products;
    using LanguageExt.UnsafeValueAccess;

    [TestFixture]
    public class SaleLineTests
    {
        private Customer? customer;

        [SetUp]
        public void Setup()
        {
            var name = Name.Create("John", "Doe");
            var email = Email.Create("john@org.com");
            customer = new Customer(email.ValueUnsafe(), name.ValueUnsafe());
        }

        Address CreateAddress()
        {
            var country = new Country("US", "United States");
            var address = Address.Create("1234 Main St", "Springfield", "IL", "62701", "7894654621", country);
            Assert.That(address.IsRight);
            return address.ValueUnsafe();
        }

        Product CreateProduct()
        {
            var name = "Product 1";
            var description = "Product 1 description";
            var price = 10.0m;
            var category = new Category("Category 1", "Category 1");
            return new Product(name, price, category, description);
        }


        [Test]
        public void ShouldCreateNewSaleLine()
        {
            var address = CreateAddress();
            Assert.That(customer, Is.Not.Null); 
            
            var product = CreateProduct();
            Assert.That(product, Is.Not.Null);

            var sale = new Sale(customer!, address);
            sale.NewSalesLine(product, 1);
            // Assert
            Assert.That(sale.SaleLines.Count, Is.EqualTo(1));
        }
    }

}
