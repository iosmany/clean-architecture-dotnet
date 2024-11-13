using ecommerce.core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.domain.Entities.Customers
{
    [Table("Customers")]
    public partial class Customer : Audit, IEntity
    {
        public Customer()
        {
            FirstName = string.Empty;
        }
        public Customer(string firstName, string? lastName=null)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [MaxLength(80)]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; private set; }
        [MaxLength(80)]
        public string? LastName { get; private set; }
        public DateOnly? DoB { get; private set; }
    }

    public partial class Customer
    {
        public IReadOnlyCollection<IError> Validate()=> EntityValidationHelper.Validate(this);

        public IReadOnlyCollection<IError> Update(string firstName, string? lastName, DateOnly? dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = dob;
            return Validate();
        }
    }

}
