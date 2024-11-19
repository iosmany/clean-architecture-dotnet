using NUnit.Framework;

namespace ecommerce.application.Sale.Commands;

public class CreateSaleCommandTests
{
    public CreateSaleCommandTests()
    {
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ExecuteAsyncWhenCalledShouldReturnTask()
    {
        var model = new CreateSaleModel();
        var cancellationToken = new CancellationToken();
        var command = new CreateSaleCommand();
        var result = command.ExecuteAsync(model, cancellationToken);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(Task)));
    }

    [Test]
    public async Task ShouldCreateSale()
    {
        var model = new CreateSaleModel();
        var cancellationToken = new CancellationToken();
        var command = new CreateSaleCommand();
        await command.ExecuteAsync(model, cancellationToken);
    }
}
