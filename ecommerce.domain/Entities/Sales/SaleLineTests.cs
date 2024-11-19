using ecommerce.domain.Entities.Customers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ecommerce.domain.Entities.Sales
{
    using ecommerce.domain.Entities.Products;

    [TestFixture]
    public class SaleLineTests
    {

        [Test]
        public void NewSalesLine_WhenCalled_AddsNewSaleLine()
        {
            // Arrange
            var customer = new Customer("Customer", "");
            var sale = new Sale(customer);
            var product = new Product("Product", 10);

            // Act
            sale.NewSalesLine(product, 1);
            // Assert
            Assert.That(sale.SaleLines.Count, Is.EqualTo(1));
        }
    }

}
