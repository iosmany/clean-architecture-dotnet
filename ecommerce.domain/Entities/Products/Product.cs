using ecommerce.core;

namespace ecommerce.domain.Entities.Products;

public partial class Product : AuditEntity
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price= price;
    }

    public string Name { get; set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public uint Stock { get; private set; }
    public int Version { get; set; }
}

public partial class Product
{
    public IReadOnlyCollection<IError> UpdatePrice(decimal price)
    {
        Price = price;
        return EntityValidationHelper.Validate(this);
    }

    public IReadOnlyCollection<IError> UpdateStock(uint stock)
    {
        Stock = stock;
        return EntityValidationHelper.Validate(this);
    }
}
