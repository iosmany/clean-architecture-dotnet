using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ecommerce.domain.Entities.Products;

[TestFixture]
public class ProductTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateProduct_WithValidData_ShouldCreateProduct()
    {
        // Arrange
        var name = "Product 1";
        var description = "Product 1 description";
        var price = 10.0m;
        var category = new Category("Category 1");

        // Act
        var result = Product.Create(name, description, price, category);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(name, result.Value.Name);
        Assert.AreEqual(description, result.Value.Description);
        Assert.AreEqual(price, result.Value.Price);
        Assert.AreEqual(category, result.Value.Category);
    }
}
