using ecommerce.core;
using LanguageExt.UnsafeValueAccess;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ecommerce.domain.Entities.Customers;

[TestFixture]
public sealed class CustomerTests
{

    [Test]
    public void ShouldCreateCustomerWithEmailAndName()
    {
        var email = Email.Create("some@test.com");
        Assert.That(email.IsRight);
        var name = Name.Create("Jane", "Doe");
        Assert.That(name.IsRight);

        var customer = new Customer(email.ValueUnsafe(), name.ValueUnsafe());
        Assert.That(customer.Name!.FirstName, Is.EqualTo("Jane"));
        Assert.That(customer.Name!.LastName, Is.EqualTo("Doe"));
    }

    [Test]
    public void ShouldThrowAnErrorWhenCustomerNameIsEmpty()
    {
        var name = Name.Create("", "");
        Assert.That(name.IsLeft);
        name.BindLeft<IError>(err => {
            Assert.That(err.Message, Is.EqualTo("First Name is required"));
            return Left(err);
        });
    }

    [Test]
    public void ShouldThrowAnErrorWhenCustomerEmailIsEmpty()
    {
        var email = Email.Create("");
        Assert.That(email.IsLeft);
        email.BindLeft<IError>(err => {
            Assert.That(err.Message, Is.EqualTo("Value is required"));
            return Left(err);
        });
    }

    [Test]
    public void ShouldUpdateCustomer()
    {
        var email = Email.Create("some@test.com");
        Assert.That(email.IsRight);
        var name = Name.Create("Jane", "Doe");
        Assert.That(name.IsRight);

        var customer = new Customer(email.ValueUnsafe(), name.ValueUnsafe());
        Assert.That(customer, Is.Not.Null);

    }
}
