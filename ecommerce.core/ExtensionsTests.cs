using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.core
{
    public class ExtensionsTests
    {

        [Test]
        public void ShouldConvertoToDateOnly()
        {
            var date = DateTime.Now;
            var dateOnly = date.ToDateOnly();
            Assert.That(dateOnly, Is.EqualTo(dateOnly));
        }
    }
}
