using ecommerce.domain.Entities.Catalog.Categories;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ecommerce.domain.Entities.Catalog.Products;

[TestFixture]
public class ProductTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateProductWithValidDataShouldCreateProduct()
    {
        var name = "Product 1";
        var description = "Product 1 description";
        var price = 10.0m;

        var category = new Category("Category 1", "Category 1");
        var product = new Product(name, price, category, description);

        Assert.That(name == product.Name, "Should be same name");
        Assert.That(description == product.Description, "Should be same description");
        Assert.That(price == product.Price, "Should be same price");
        Assert.That(category == product.Category, "Category does not match");
    }
}
