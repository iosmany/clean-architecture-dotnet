using ecommerce.core.EF;
using ecommerce.domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.domain.Entities.Sales
{
    [Table("Sales")]
    public class Sale : AuditEntity
    {
        private Sale()
        {
        }

        public Sale(Customers.Customer customer, Address address) : this()
        {
            Customer = customer;
            Address = address;
        }

        public virtual Address Address { get; private set; }
        public virtual Customers.Customer? Customer { get; private set; } //lazy loading
        public DateTimeOffset Date { get; private set; }


        readonly List<SaleLine> _saleLines = new List<SaleLine>();
        public virtual IReadOnlyCollection<SaleLine> SaleLines => _saleLines;

        public void NewSalesLine(Product product, int quantity)
        {
            _saleLines.Add(new SaleLine(product, quantity, this));
        }
    }
}
