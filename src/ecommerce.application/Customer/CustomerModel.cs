
namespace ecommerce.application.Customer
{
    using domain.Entities.Customers;
    public class CustomerModel
    {
        public CustomerModel(Customer customer)
        {
            ArgumentNullException
                .ThrowIfNull(customer);

            Id = customer.Id;
            Email = customer.Email.Value;
            FirstName = customer.Name.FirstName;
            LastName = customer.Name.LastName;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
