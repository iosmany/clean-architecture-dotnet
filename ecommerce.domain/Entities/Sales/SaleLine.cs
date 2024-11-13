using ecommerce.core.EF;
using ecommerce.domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.domain.Entities.Sales
{
    [Table("SaleLines")]
    public class SaleLine : Audit, IEntity
    {
        public SaleLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public long Id { get; private set; }

        [Column("Sale"), GtZero]
        public long SaleId { get; private set; }
        public virtual Sale? Sale { get; private set; }

        [Column("Product"), GtZero]
        public long ProductId { get; private set; }
        public virtual Products.Product Product { get; private set; }

        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Total => decimal.Round(Quantity * Price, 2);
    }
}
