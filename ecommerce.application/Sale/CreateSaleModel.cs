

namespace ecommerce.application.Sale;

public class CreateSaleModel
{
    public long CustomerId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}
