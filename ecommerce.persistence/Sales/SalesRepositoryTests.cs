using ecommerce.application;
using Moq.AutoMock;
using NUnit.Framework;

namespace ecommerce.persistence.Sales;

using domain.Entities.Customers;
using domain.Entities.Sales;
using domain.Entities;
using domain.Entities.Catalog.Categories;
using domain.Entities.Catalog.Products;
using domain.Entities.Core;
using LanguageExt.UnsafeValueAccess;
using Moq.EntityFrameworkCore;
using ecommerce.application.Persistence;

public class SalesRepositoryTests
{
    private AutoMocker _autoMocker;

    public SalesRepositoryTests()
    {
        _autoMocker = new AutoMocker();
    }

    [SetUp]
    public void Setup()
    {
        var name = Name.Create("John", "Doe");
        var email = Email.Create("john@org.com");
        var customer = new Customer(email.ValueUnsafe(), name.ValueUnsafe());

        var country = new Country("US", "United States");
        var address = Address.Create("1234 Main St", "Springfield", "IL", "62701", "7894654621", country);

        var category = new Category("Category 1", "Category 1");    
        var product = new Product("Product 1", 10.0m, new Category("Category 1", "Category 1"), "Product 1 description");

        var sale = new Sale(customer, address.ValueUnsafe());

        _autoMocker.GetMock<IDatabaseService>()
            .Setup(c => c.Set<Sale>())
            .ReturnsDbSet(new List<Sale>() { sale });    
    }

    [Test]
    public void ShouldCreateRepositoryInstance()
    {
        ISaleRepository _repository = _autoMocker.CreateInstance<SaleRepository>(); 
        Assert.That(_repository, Is.Not.Null);
    }
}
