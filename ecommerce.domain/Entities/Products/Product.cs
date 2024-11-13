using ecommerce.core;
using ecommerce.core.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.domain.Entities.Products
{
    [Table("Products")]
    public partial class Product : Audit, IEntity
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price= price;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [MaxLength(80)]
        [IsUnicode(false)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public uint Stock { get; private set; }

        [ConcurrencyCheck]
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
}
