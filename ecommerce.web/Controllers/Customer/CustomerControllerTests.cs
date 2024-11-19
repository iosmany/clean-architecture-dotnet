using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ecommerce.web.Controllers.Customer
{
    [TestFixture]
    public class CustomerControllerTests 
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var controller = new CustomerController();
            var result = controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
        }

    }
}
