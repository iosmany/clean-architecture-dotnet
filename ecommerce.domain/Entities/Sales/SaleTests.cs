using ecommerce.domain.Entities.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.Entities.Sales
{
    internal class SaleTests
    {
        [Test]
        public void ShouldCreateSaleLine()
        {
            var product = new Product("Some product", 10.0m);
            var saleLine = new SaleLine(product, 1);
            Assert.That(saleLine.Product, Is.EqualTo(product));
            Assert.That(saleLine.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void ShouldUpdateSaleLine()
        {
            var product = new Product("Some product", 10.0m);
            var saleLine = new SaleLine(product, 1);
            Assert.That(saleLine.Quantity, Is.EqualTo(2));
        }


    }
}
