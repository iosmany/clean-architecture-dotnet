using NUnit.Framework;

namespace ecommerce.core
{
    public class ExtensionsTests
    {

        [Test]
        public void ShouldConvertoToDateOnly()
        {
            var date = DateTime.Now;
            var dateOnly = date.ToDateOnly();
        }
    }
}
