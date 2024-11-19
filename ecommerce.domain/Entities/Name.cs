using ecommerce.core;

namespace ecommerce.domain.Entities
{
    public class Name : ValueObject
    {
        protected Name() { }
        private Name(string firstName, string? lastName = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string? LastName { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName ?? string.Empty;
        }

        public static Either<IError, Name> Create(string firstName, string? lastName = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Left(ErrorFactory.New("First Name is required"));

            return new Name(firstName, lastName);
        }
    }
}
