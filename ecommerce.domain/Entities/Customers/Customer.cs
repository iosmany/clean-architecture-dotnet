namespace ecommerce.domain.Entities.Customers;

public class Customer : AuditEntity
{
    protected Customer() //we make protected the default constructor to avoid the creation of a Customer without a Name
    {
    }

    internal Customer(Email email, Name name) : this()
    {
        Email = email;
        Name = name;
    }
    
    public Name? Name { get; private set; }
    public Email? Email { get; private set; }
    public DateOnly? DoB { get; private set; }
}
