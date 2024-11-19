using ecommerce.core;
using LanguageExt;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

namespace ecommerce.domain.Entities;

public class Email : ValueObject
{
    public string Value { get; }

    protected Email() { }
    private  Email(string value) 
    {
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }

    readonly static string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";    
    public static Either<IError, Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Left(ErrorFactory.New("Value is required", "Value"));

        value = value.Trim();

        if (value.Length > 150)
            return Left(ErrorFactory.New("Value is too long", "Value"));

        if (Regex.IsMatch(value, pattern))
            return new Email(value);

        return Left(ErrorFactory.New("Value is invalid", "Value"));
    }
}
