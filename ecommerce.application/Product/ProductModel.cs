
namespace ecommerce.application.Product;

using domain.Entities.Catalog.Products;

public class ProductModel
{
    public ProductModel()
    {
        Name = string.Empty;
    }

    internal ProductModel(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Stock = product.Stock;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public uint Stock { get; set; }

}
