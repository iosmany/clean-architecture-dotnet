using ecommerce.core.EF;
using ecommerce.domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.domain.Entities.Sales
{
    [Table("Sales")]
    public partial class Sale : Audit, IEntity
    {
        public Sale()
        {
            _saleLines = new List<SaleLine>();
        }

        public Sale(Customers.Customer customer, List<SaleLine> saleLines) : this()
        {
            Customer=customer;
            _saleLines = saleLines;
        }

        public long Id { get; }

        [Column("Customer"), GtZero]
        public long CustomerId { get; private set; }
        public virtual Customers.Customer? Customer { get; private set; } //lazy loading

        [NotDefault]
        public DateTimeOffset Date { get; set; }

        List<SaleLine> _saleLines;
        public virtual IReadOnlyCollection<SaleLine> SaleLines
        {
            get => _saleLines;
        }
    }

    public partial class Sale
    {
        public SaleLine NewSaleLine(Product product, int quantity)
        {
            return new SaleLine(product, quantity);
        }
    }
}
