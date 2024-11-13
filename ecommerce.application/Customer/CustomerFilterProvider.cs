using ecommerce.core.EF;

namespace ecommerce.application.Customer
{
    using ecommerce.domain.Entities.Customers;
    using System.Linq.Expressions;

    public sealed class CustomerFilterBuilder
    {
        readonly PredicateBuilder<Customer> builder = new PredicateBuilder<Customer>();
        public CustomerFilterBuilder()
        {
        }

        public CustomerFilterBuilder WithFirstName(string firstName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                builder.And(c => c.FirstName.Contains(firstName));
            return this;
        }
        public CustomerFilterBuilder WithLastName(string lastName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                builder.And(c => c.LastName != null && c.LastName.Contains(lastName));
            return this;
        }
        public CustomerFilterBuilder WithDoB(DateOnly? dob)
        {
            if (dob.HasValue)
                builder.And(c => c.DoB == dob);
            return this;
        }

        public CustomerFilterBuilder WithId(long id)
        {
            builder.And(c => c.Id == id);
            return this;
        }

        public Expression<System.Func<Customer, bool>> Build()
        {
            builder.Compile();
            return builder.Build();
        }
    }
}
