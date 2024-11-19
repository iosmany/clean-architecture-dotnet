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
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

    }
}
