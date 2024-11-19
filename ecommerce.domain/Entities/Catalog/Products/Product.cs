using ecommerce.core;

namespace ecommerce.domain.Entities.Catalog.Products;

using domain.Entities.Catalog.Categories;

public partial class Product : AuditEntity
{
    protected Product()
    {
    }
    internal Product(string name, decimal price, Category category, string? description =null) : this()
    {
        Name = name;
        Price= price;
        Category = category;
        Description = description;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public uint Stock { get; private set; }
    public virtual Category Category { get; private set; }
    public int Version { get; private set; }
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
