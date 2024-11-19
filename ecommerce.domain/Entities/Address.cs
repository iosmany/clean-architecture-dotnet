using ecommerce.core;
using ecommerce.domain.Entities.Core;
using LanguageExt;

namespace ecommerce.domain.Entities;

using static LanguageExt.Prelude;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }
    public virtual Country Country { get; }

    private Address(string street, string city, string state, string zipCode, Country country)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return ZipCode;
    }

    public static Either<IError, Address> Create(string street, string city, string state, string zipCode, Country country)
    {
        if (string.IsNullOrWhiteSpace(street))
            return Left(ErrorFactory.New("Street is required", nameof(street)));
        if (string.IsNullOrWhiteSpace(state))
            return Left(ErrorFactory.New("State is required", nameof(state)));
        if (string.IsNullOrWhiteSpace(zipCode))
            return Left(ErrorFactory.New("ZipCode is required", nameof(zipCode)));

        return new Address(street, city, state, zipCode, country);
    }


}
