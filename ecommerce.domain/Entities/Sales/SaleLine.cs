using ecommerce.domain.Entities.Catalog.Products;

namespace ecommerce.domain.Entities.Sales;

public class SaleLine : AuditEntity
{
    private SaleLine()
    {
    }

    internal SaleLine(Product product, int quantity, Sale sale) : this()
    {
        Sale= sale;
        Product = product;
        Quantity = quantity;
    }

    public virtual Sale? Sale { get; private set; }
    public virtual Product? Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Total => decimal.Round(Quantity * Price, 2);

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
