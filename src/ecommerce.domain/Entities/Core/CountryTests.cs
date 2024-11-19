

using NUnit.Framework;

namespace ecommerce.domain.Entities.Core;


[TestFixture]
public class CountryTests
{
    [Test]
    public void Country_Should_Be_Created()
    {
        var country = new Country("NG", "Nigeria");
        Assert.That("Nigeria", Is.EqualTo(country.Name));
    }
}
